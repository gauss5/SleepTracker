<template>
  <div class="min-h-screen bg-deep">
    <AppNavbar />
    <div class="max-w-4xl mx-auto px-8 pt-28 pb-16">

      <div class="flex justify-between items-center mb-10">
        <div>
          <h1 class="font-display font-bold text-3xl mb-1">Registros de sono</h1>
          <p class="text-muted">Gerencie seus registros diários</p>
        </div>
        <button @click="showForm = true" class="btn-primary">+ Novo registro</button>
      </div>

      <!-- Form modal -->
      <div v-if="showForm" class="fixed inset-0 bg-black/60 backdrop-blur-sm z-50 flex items-center justify-center px-4">
        <div class="card p-8 w-full max-w-md">
          <h2 class="font-display font-bold text-xl mb-6">{{ editing ? 'Editar' : 'Novo' }} registro</h2>
          <form @submit.prevent="handleSave" class="flex flex-col gap-4">
            <div>
              <label class="label">Data</label>
              <input v-model="form.sleepDate" type="date" class="input" required />
            </div>
            <div class="grid grid-cols-2 gap-4">
              <div>
                <label class="label">Hora de dormir</label>
                <input v-model="form.bedTime" type="time" class="input" required />
              </div>
              <div>
                <label class="label">Hora de acordar</label>
                <input v-model="form.wakeTime" type="time" class="input" required />
              </div>
            </div>
            <div>
              <label class="label">Qualidade (1–10)</label>
              <input v-model.number="form.quality" type="number" min="1" max="10" class="input" required />
            </div>
            <div>
              <label class="label">Notas (opcional)</label>
              <textarea v-model="form.notes" class="input resize-none h-20" placeholder="Como foi seu sono?"></textarea>
            </div>
            <div v-if="formError" class="bg-red-500/10 text-red-400 text-sm px-4 py-3 rounded-xl">{{ formError }}</div>
            <div class="flex gap-3 mt-2">
              <button type="button" @click="closeForm" class="btn-ghost flex-1 py-3 text-sm">Cancelar</button>
              <button type="submit" class="btn-primary flex-1" :disabled="saving">
                {{ saving ? 'Salvando...' : 'Salvar' }}
              </button>
            </div>
          </form>
        </div>
      </div>

      <!-- Records list -->
      <div class="card divide-y divide-white/[0.05]">
        <div v-if="sleep.loading" class="p-8 text-muted text-sm text-center">Carregando...</div>
        <div v-else-if="sleep.records.length === 0" class="p-8 text-muted text-sm text-center">
          Nenhum registro ainda. Adicione seu primeiro!
        </div>
        <div
          v-else
          v-for="r in sleep.records" :key="r.id"
          class="flex items-center justify-between p-5 hover:bg-white/[0.02] transition-colors"
        >
          <div>
            <div class="font-medium">{{ formatDate(r.sleepDate) }}</div>
            <div class="text-muted text-xs mt-0.5">{{ r.bedTime }} → {{ r.wakeTime }}</div>
            <div v-if="r.notes" class="text-muted text-xs mt-1 italic">{{ r.notes }}</div>
          </div>
          <div class="flex items-center gap-6">
            <div class="text-right">
              <div class="font-display font-bold">{{ r.durationHours }}h {{ r.durationMinutes }}min</div>
              <div class="text-xs mt-0.5" :class="r.quality >= 7 ? 'text-teal' : 'text-muted'">⭐ {{ r.quality }}/10</div>
            </div>
            <div class="flex gap-2">
              <button @click="startEdit(r)" class="text-muted hover:text-white text-xs px-3 py-1.5 rounded-lg border border-white/10 hover:border-white/20 transition-all">Editar</button>
              <button @click="handleDelete(r.id)" class="text-muted hover:text-red-400 text-xs px-3 py-1.5 rounded-lg border border-white/10 hover:border-red-400/30 transition-all">Excluir</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, reactive, onMounted } from 'vue'
import AppNavbar from '@/components/AppNavbar.vue'
import { useSleepStore } from '@/stores/sleep'

const sleep     = useSleepStore()
const showForm  = ref(false)
const editing   = ref(null)
const saving    = ref(false)
const formError = ref('')

const form = reactive({ sleepDate: '', bedTime: '', wakeTime: '', quality: 7, notes: '' })

onMounted(() => sleep.fetchAll())

function closeForm() {
  showForm.value  = false
  editing.value   = null
  formError.value = ''
  Object.assign(form, { sleepDate: '', bedTime: '', wakeTime: '', quality: 7, notes: '' })
}

function startEdit(record) {
  editing.value = record.id
  Object.assign(form, {
    sleepDate: record.sleepDate,
    bedTime:   record.bedTime,
    wakeTime:  record.wakeTime,
    quality:   record.quality,
    notes:     record.notes || ''
  })
  showForm.value = true
}

async function handleSave() {
  saving.value    = true
  formError.value = ''
  try {
    if (editing.value) {
      await sleep.update(editing.value, { ...form })
    } else {
      await sleep.create({ ...form })
    }
    closeForm()
  } catch (e) {
    formError.value = e.response?.data?.message || 'Erro ao salvar.'
  } finally {
    saving.value = false
  }
}

async function handleDelete(id) {
  if (!confirm('Excluir este registro?')) return
  await sleep.remove(id)
}

function formatDate(d) {
  if (!d) return '–'
  return new Date(d).toLocaleDateString('pt-BR', { weekday: 'long', day: '2-digit', month: 'long' })
}
</script>
