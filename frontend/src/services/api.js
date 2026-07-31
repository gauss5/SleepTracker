import axios from 'axios'
import { useAuthStore } from '@/stores/auth'

const api = axios.create({
  baseURL: '/api',
  timeout: 10000,
  headers: { 'Content-Type': 'application/json' }
})

// ── Request interceptor: injeta token JWT ──────────────
api.interceptors.request.use(config => {
  const token = localStorage.getItem('token')
  if (token) config.headers.Authorization = `Bearer ${token}`
  return config
})

// ── Response interceptor: trata erros globalmente ──────
api.interceptors.response.use(
  res => res,
  err => {
    if (err.response?.status === 401) {
      // Token expirado — faz logout e redireciona
      const auth = useAuthStore()
      auth.logout()
      window.location.href = '/login'
    }
    return Promise.reject(err)
  }
)

// ── Auth ───────────────────────────────────────────────
export const authApi = {
  login:    (data) => api.post('/auth/login', data),
  register: (data) => api.post('/auth/register', data),
  me:       ()     => api.get('/auth/me'),
}

// ── Sleep Records ──────────────────────────────────────
export const sleepApi = {
  getAll:   ()       => api.get('/sleep'),
  getById:  (id)     => api.get(`/sleep/${id}`),
  create:   (data)   => api.post('/sleep', data),
  update:   (id, d)  => api.put(`/sleep/${id}`, d),
  remove:   (id)     => api.delete(`/sleep/${id}`),
  getStats: ()       => api.get('/sleep/stats'),
}

// ── User ───────────────────────────────────────────────
export const userApi = {
  getProfile:    ()     => api.get('/user/profile'),
  updateProfile: (data) => api.put('/user/profile', data),
}

export default api
