import { defineStore } from 'pinia'
import { ref } from 'vue'
import { sleepApi } from '@/services/api'

export const useSleepStore = defineStore('sleep', () => {
  const records = ref([])
  const stats   = ref(null)
  const loading = ref(false)
  const error   = ref(null)

  async function fetchAll() {
    loading.value = true
    try {
      const { data } = await sleepApi.getAll()
      records.value = data
    } catch (e) {
      error.value = e.response?.data?.message || 'Erro ao buscar registros'
    } finally {
      loading.value = false
    }
  }

  async function fetchStats() {
    const { data } = await sleepApi.getStats()
    stats.value = data
  }

  async function create(payload) {
    const { data } = await sleepApi.create(payload)
    records.value.unshift(data)
    return data
  }

  async function update(id, payload) {
    const { data } = await sleepApi.update(id, payload)
    const idx = records.value.findIndex(r => r.id === id)
    if (idx !== -1) records.value[idx] = data
    return data
  }

  async function remove(id) {
    await sleepApi.remove(id)
    records.value = records.value.filter(r => r.id !== id)
  }

  return { records, stats, loading, error, fetchAll, fetchStats, create, update, remove }
})
