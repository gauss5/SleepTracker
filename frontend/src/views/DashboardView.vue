<template>
  <div class="min-h-screen bg-deep">
    <AppNavbar />
    <div class="max-w-6xl mx-auto px-8 pt-28 pb-16">

      <div class="mb-10">
        <h1 class="font-display font-bold text-3xl mb-1">
          Olá, {{ auth.user?.name?.split(' ')[0] }} 👋
        </h1>
        <p class="text-muted">Aqui está um resumo do seu sono</p>
      </div>

      <!-- Stat cards -->
      <div class="grid grid-cols-4 gap-4 mb-8">
        <div v-for="s in statCards" :key="s.label" class="card p-6">
          <span class="text-xs text-muted uppercase tracking-widest">{{ s.label }}</span>
          <div class="font-display font-bold text-2xl mt-2 mb-1">{{ s.value }}</div>
          <span class="text-xs" :class="s.up ? 'text-teal' : 'text-muted'">{{ s.change }}</span>
        </div>
      </div>

      <!-- Chart -->
      <div class="card p-7 mb-8">
        <h2 class="font-display font-bold mb-6">Horas de sono — últimos 7 dias</h2>
        <apexchart type="bar" height="220" :options="chartOptions" :series="chartSeries" />
      </div>

      <!-- Recent records -->
      <div class="card p-7">
        <div class="flex justify-between items-center mb-6">
          <h2 class="font-display font-bold">Registros recentes</h2>
          <RouterLink to="/sleep" class="text-accent text-sm hover:underline">Ver todos →</RouterLink>
        </div>
        <div v-if="sleep.loading" class="text-muted text-sm">Carregando...</div>
        <div v-else-if="sleep.records.length === 0" class="text-muted text-sm">
          Nenhum registro ainda.
          <RouterLink to="/sleep" class="text-accent hover:underline ml-1">Adicionar primeiro registro</RouterLink>
        </div>
        <div v-else class="flex flex-col gap-3">
          <div
            v-for="r in sleep.records.slice(0, 5)" :key="r.id"
            class="flex items-center justify-between py-3 border-b border-white/[0.05] last:border-0"
          >
            <div>
              <div class="font-medium text-sm">{{ formatDate(r.sleepDate) }}</div>
              <div class="text-muted text-xs mt-0.5">{{ r.bedTime }} → {{ r.wakeTime }}</div>
            </div>
            <div class="text-right">
              <div class="font-display font-bold">{{ r.durationHours }}h {{ r.durationMinutes }}min</div>
              <div class="text-xs" :class="r.quality >= 7 ? 'text-teal' : 'text-muted'">
                Qualidade: {{ r.quality }}/10
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { onMounted, computed } from 'vue'
import { RouterLink } from 'vue-router'
import AppNavbar from '@/components/AppNavbar.vue'
import { useAuthStore } from '@/stores/auth'
import { useSleepStore } from '@/stores/sleep'

const auth  = useAuthStore()
const sleep = useSleepStore()

onMounted(() => {
  sleep.fetchAll()
  sleep.fetchStats()
})

const statCards = computed(() => [
  { label: 'Média semanal',    value: sleep.stats?.weeklyAvg  || '–',    change: '↑ 8% vs semana anterior', up: true  },
  { label: 'Qualidade média',  value: sleep.stats?.avgQuality || '–',    change: 'De 0 a 10',               up: false },
  { label: 'Melhor noite',     value: sleep.stats?.bestNight  || '–',    change: 'Esta semana',             up: false },
  { label: 'Sequência',        value: sleep.stats?.streak     || '0 dias', change: 'Dias consecutivos',    up: true  },
])

const chartOptions = {
  chart: { background: 'transparent', toolbar: { show: false } },
  theme: { mode: 'dark' },
  colors: ['#6c8dfa'],
  plotOptions: { bar: { borderRadius: 6 } },
  dataLabels: { enabled: false },
  xaxis: { categories: ['Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'], labels: { style: { colors: '#7b82a8' } } },
  yaxis: { labels: { style: { colors: '#7b82a8' }, formatter: v => v + 'h' } },
  grid: { borderColor: 'rgba(255,255,255,0.05)' },
  tooltip: { theme: 'dark' },
}

const chartSeries = [{ name: 'Horas', data: [6.5, 8, 5.5, 9, 7.2, 9.5, 8.5] }]

function formatDate(dateStr) {
  if (!dateStr) return '–'
  return new Date(dateStr).toLocaleDateString('pt-BR', { weekday: 'short', day: '2-digit', month: 'short' })
}
</script>
