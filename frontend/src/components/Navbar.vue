<template>
  <nav class="navbar" :class="{ scrolled: isScrolled }">
    <div class="nav-inner">
      <a href="#" class="logo">
        <svg width="28" height="28" viewBox="0 0 28 28" fill="none">
          <circle cx="14" cy="14" r="13" stroke="var(--accent)" stroke-width="1.5"/>
          <path d="M14 6C10 6 7 9.5 7 14c0 3.9 2.5 7.2 6 8.5V14l5-5.5C16.8 6.9 15.5 6 14 6z" fill="var(--accent)" opacity="0.9"/>
        </svg>
        SleepTracker
      </a>
      <ul class="nav-links">
        <li><a href="#features">Recursos</a></li>
        <li><a href="#stats">Estatísticas</a></li>
        <li><a href="#cta">Começar</a></li>
      </ul>
      <a href="#cta" class="btn-nav">Criar conta</a>
    </div>
  </nav>
</template>

<script setup>
import { ref, onMounted, onUnmounted } from 'vue'

const isScrolled = ref(false)

function onScroll() {
  isScrolled.value = window.scrollY > 40
}

onMounted(() => window.addEventListener('scroll', onScroll))
onUnmounted(() => window.removeEventListener('scroll', onScroll))
</script>

<style scoped>
.navbar {
  position: fixed;
  top: 0; left: 0; right: 0;
  z-index: 100;
  padding: 20px 0;
  transition: background 0.3s, padding 0.3s, backdrop-filter 0.3s;
}

.navbar.scrolled {
  background: rgba(7, 8, 15, 0.85);
  backdrop-filter: blur(16px);
  padding: 14px 0;
  border-bottom: 1px solid var(--border);
}

.nav-inner {
  max-width: 1100px;
  margin: 0 auto;
  padding: 0 32px;
  display: flex;
  align-items: center;
  gap: 40px;
}

.logo {
  font-family: var(--font-display);
  font-weight: 700;
  font-size: 1.1rem;
  color: var(--text-primary);
  text-decoration: none;
  display: flex;
  align-items: center;
  gap: 10px;
  letter-spacing: -0.02em;
}

.nav-links {
  display: flex;
  list-style: none;
  gap: 32px;
  margin-left: auto;
}

.nav-links a {
  color: var(--text-muted);
  text-decoration: none;
  font-size: 0.9rem;
  font-weight: 400;
  transition: color 0.2s;
}

.nav-links a:hover { color: var(--text-primary); }

.btn-nav {
  background: var(--accent);
  color: #fff;
  text-decoration: none;
  padding: 8px 20px;
  border-radius: 8px;
  font-size: 0.875rem;
  font-weight: 500;
  transition: background 0.2s, transform 0.2s;
}

.btn-nav:hover {
  background: var(--accent-soft);
  transform: translateY(-1px);
}
</style>
