<template>
  <div class="min-h-screen bg-deep">
    <AppNavbar />
    <div class="max-w-xl mx-auto px-8 pt-28 pb-16">
      <h1 class="font-display font-bold text-3xl mb-1">Perfil</h1>
      <p class="text-muted mb-10">Gerencie suas informações</p>

      <div class="card p-8">
        <div class="flex items-center gap-4 mb-8 pb-8 border-b border-white/[0.06]">
          <div class="w-14 h-14 rounded-full bg-accent/20 flex items-center justify-center text-accent font-display font-bold text-xl">
            {{ auth.user?.name?.[0]?.toUpperCase() }}
          </div>
          <div>
            <div class="font-display font-bold text-lg">{{ auth.user?.name }}</div>
            <div class="text-muted text-sm">{{ auth.user?.email }}</div>
          </div>
        </div>

        <form @submit.prevent="handleUpdate" class="flex flex-col gap-5">
          <div>
            <label class="label">Nome</label>
            <input v-model="form.name" type="text" class="input" required />
          </div>
          <div>
            <label class="label">E-mail</label>
            <input v-model="form.email" type="email" class="input" required />
          </div>
          <div>
            <label class="label">Nova senha <span class="normal-case text-muted">(deixe em branco para manter)</span></label>
            <input v-model="form.password" type="password" class="input" placeholder="Nova senha" />
          </div>

          <div v-if="error"   class="bg-red-500/10 text-red-400 text-sm px-4 py-3 rounded-xl">{{ error }}</div>
          <div v-if="success" class="bg-teal/10 text-teal text-sm px-4 py-3 rounded-xl">✓ Perfil atualizado!</div>

          <button type="submit" class="btn-primary" :disabled="loading">
            {{ loading ? 'Salvando...' : 'Salvar alterações' }}
          </button>
        </form>
      </div>

      <div class="mt-6 card p-6">
        <h2 class="font-display font-bold mb-4 text-red-400">Zona de perigo</h2>
        <button @click="handleLogout" class="text-sm text-red-400 hover:text-red-300 border border-red-400/20 hover:border-red-400/40 px-4 py-2 rounded-xl transition-all">
          Sair da conta
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, reactive, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import AppNavbar from '@/components/AppNavbar.vue'
import { useAuthStore } from '@/stores/auth'
import { userApi } from '@/services/api'

const auth    = useAuthStore()
const router  = useRouter()
const loading = ref(false)
const error   = ref('')
const success = ref(false)

const form = reactive({
  name:     auth.user?.name  || '',
  email:    auth.user?.email || '',
  password: ''
})

async function handleUpdate() {
  loading.value = true
  error.value   = ''
  success.value = false
  try {
    const payload = { name: form.name, email: form.email }
    if (form.password) payload.password = form.password
    const { data } = await userApi.updateProfile(payload)
    auth.user = data
    localStorage.setItem('user', JSON.stringify(data))
    success.value = true
    form.password = ''
  } catch (e) {
    error.value = e.response?.data?.message || 'Erro ao atualizar perfil.'
  } finally {
    loading.value = false
  }
}

function handleLogout() {
  auth.logout()
  router.push('/')
}
</script>
