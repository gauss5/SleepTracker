<template>
  <div class="min-h-screen bg-deep flex items-center justify-center px-4">
    <div class="w-full max-w-md">
      <RouterLink to="/" class="flex items-center gap-2.5 font-display font-bold text-white justify-center mb-10">
        <svg width="26" height="26" viewBox="0 0 28 28" fill="none">
          <circle cx="14" cy="14" r="13" stroke="#6c8dfa" stroke-width="1.5"/>
          <path d="M14 6C10 6 7 9.5 7 14c0 3.9 2.5 7.2 6 8.5V14l5-5.5C16.8 6.9 15.5 6 14 6z" fill="#6c8dfa"/>
        </svg>
        SleepTracker
      </RouterLink>

      <div class="card p-9">
        <h1 class="font-display font-bold text-2xl mb-1">Bem-vindo de volta</h1>
        <p class="text-muted text-sm mb-8">Entre na sua conta para continuar</p>

        <form @submit.prevent="handleLogin" class="flex flex-col gap-5">
          <div>
            <label class="label">E-mail</label>
            <input v-model="form.email" type="email" class="input" placeholder="seu@email.com" required />
          </div>
          <div>
            <label class="label">Senha</label>
            <input v-model="form.password" type="password" class="input" placeholder="Sua senha" required />
          </div>

          <div v-if="error" class="bg-red-500/10 text-red-400 text-sm px-4 py-3 rounded-xl">
            {{ error }}
          </div>

          <button type="submit" class="btn-primary w-full justify-center mt-1" :disabled="loading">
            {{ loading ? 'Entrando...' : 'Entrar →' }}
          </button>
        </form>
      </div>

      <p class="text-center text-muted text-sm mt-6">
        Não tem conta?
        <RouterLink to="/register" class="text-accent hover:underline ml-1">Criar conta grátis</RouterLink>
      </p>
    </div>
  </div>
</template>

<script setup>
import { ref, reactive } from 'vue'
import { RouterLink, useRouter, useRoute } from 'vue-router'
import { useAuthStore } from '@/stores/auth'

const auth    = useAuthStore()
const router  = useRouter()
const route   = useRoute()
const loading = ref(false)
const error   = ref('')
const form    = reactive({ email: '', password: '' })

async function handleLogin() {
  loading.value = true
  error.value   = ''
  try {
    await auth.login(form.email, form.password)
    const redirect = route.query.redirect || '/dashboard'
    router.push(redirect)
  } catch (e) {
    error.value = e.response?.data?.message || 'E-mail ou senha incorretos.'
  } finally {
    loading.value = false
  }
}
</script>
