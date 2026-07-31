<template>
  <nav
    class="fixed top-0 left-0 right-0 z-50 transition-all duration-300"
    :class="scrolled ? 'bg-deep/85 backdrop-blur-xl border-b border-white/[0.06]' : ''"
  >
    <div class="max-w-6xl mx-auto px-8 flex items-center gap-10 py-4">
      <!-- Logo -->
      <RouterLink to="/" class="flex items-center gap-2.5 font-display font-bold text-white">
        <svg width="26" height="26" viewBox="0 0 28 28" fill="none">
          <circle cx="14" cy="14" r="13" stroke="#6c8dfa" stroke-width="1.5"/>
          <path d="M14 6C10 6 7 9.5 7 14c0 3.9 2.5 7.2 6 8.5V14l5-5.5C16.8 6.9 15.5 6 14 6z" fill="#6c8dfa"/>
        </svg>
        SleepTracker
      </RouterLink>

      <!-- Links públicos -->
      <template v-if="!auth.isAuthenticated">
        <ul class="flex gap-8 ml-auto list-none">
          <li><RouterLink to="/#features" class="text-muted hover:text-white text-sm transition-colors">Recursos</RouterLink></li>
        </ul>
        <div class="flex gap-3">
          <RouterLink to="/login" class="btn-ghost text-sm px-4 py-2">Entrar</RouterLink>
          <RouterLink to="/register" class="btn-primary text-sm px-5 py-2.5">Criar conta</RouterLink>
        </div>
      </template>

      <!-- Links autenticados -->
      <template v-else>
        <ul class="flex gap-8 ml-auto list-none">
          <li><RouterLink to="/dashboard" class="text-sm text-muted hover:text-white transition-colors">Dashboard</RouterLink></li>
          <li><RouterLink to="/sleep" class="text-sm text-muted hover:text-white transition-colors">Registros</RouterLink></li>
          <li><RouterLink to="/profile" class="text-sm text-muted hover:text-white transition-colors">Perfil</RouterLink></li>
        </ul>
        <button @click="handleLogout" class="btn-ghost text-sm px-4 py-2">Sair</button>
      </template>
    </div>
  </nav>
</template>

<script setup>
import { ref, onMounted, onUnmounted } from 'vue'
import { RouterLink, useRouter } from 'vue-router'
import { useAuthStore } from '@/stores/auth'

const auth   = useAuthStore()
const router = useRouter()
const scrolled = ref(false)

function onScroll() { scrolled.value = window.scrollY > 40 }
onMounted(() => window.addEventListener('scroll', onScroll))
onUnmounted(() => window.removeEventListener('scroll', onScroll))

function handleLogout() {
  auth.logout()
  router.push('/')
}
</script>
