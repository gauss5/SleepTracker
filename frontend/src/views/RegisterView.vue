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
        <h1 class="font-display font-bold text-2xl mb-1">Crie sua conta</h1>
        <p class="text-muted text-sm mb-8">Grátis para sempre. Sem cartão de crédito.</p>

        <form @submit.prevent="handleRegister" class="flex flex-col gap-5">
          <div>
            <label class="label">Nome</label>
            <input v-model="form.name" type="text" class="input" placeholder="Seu nome completo" required />
          </div>
          <div>
            <label class="label">E-mail</label>
            <input v-model="form.email" type="email" class="input" placeholder="seu@email.com" required />
          </div>
          <div>
            <label class="label">Senha</label>
            <input v-model="form.password" type="password" class="input" placeholder="Mínimo 8 caracteres" minlength="8" required />
          </div>

          <div v-if="error" class="bg-red-500/10 text-red-400 text-sm px-4 py-3 rounded-xl">
            {{ error }}
          </div>
          <div v-if="success" class="bg-teal/10 text-teal text-sm px-4 py-3 rounded-xl">
            ✓ Conta criada! Redirecionando...
          </div>

          <button type="submit" class="btn-primary w-full justify-center mt-1" :disabled="loading">
            {{ loading ? 'Criando conta...' : 'Criar conta grátis →' }}
          </button>
        </form>
      </div>

      <p class="text-center text-muted text-sm mt-6">
        Já tem conta?
        <RouterLink to="/login" class="text-accent hover:underline ml-1">Entrar</RouterLink>
      </p>
    </div>
  </div>
</template>

<script setup>
import { ref, reactive } from 'vue'
import { RouterLink, useRouter } from 'vue-router'
import { useAuthStore } from '@/stores/auth'

const auth    = useAuthStore()
const router  = useRouter()
const loading = ref(false)
const error   = ref('')
const success = ref(false)
const form    = reactive({ name: '', email: '', password: '' })

async function handleRegister() {
  loading.value = true
  error.value   = ''
  success.value = false
  try {
    await auth.register(form.name, form.email, form.password)
    success.value = true
    setTimeout(() => router.push('/dashboard'), 1000)
  } catch (e) {
    error.value = e.response?.data?.message || 'Erro ao criar conta. Tente novamente.'
  } finally {
    loading.value = false
  }
}
</script>
