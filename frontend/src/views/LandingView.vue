<template>
  <div class="min-h-screen bg-deep overflow-hidden">
    <AppNavbar />

    <!-- Hero -->
    <section class="max-w-6xl mx-auto px-8 pt-36 pb-24 flex items-center gap-16">
      <div class="flex-1 animate-[fadeUp_0.8s_ease_both]">
        <span class="inline-block bg-accent/10 border border-accent/20 text-accent text-xs font-medium px-4 py-1.5 rounded-full mb-6 tracking-wide">
          ✦ Monitore seu sono com inteligência
        </span>
        <h1 class="font-display font-extrabold tracking-tight leading-[1.1] mb-5" style="font-size: clamp(2.8rem,5vw,4.2rem)">
          Durma melhor.<br/>
          <span class="gradient-text">Viva melhor.</span>
        </h1>
        <p class="text-muted text-lg leading-relaxed max-w-lg mb-10">
          Registre, analise e melhore seus padrões de sono com dados precisos e insights personalizados.
        </p>
        <div class="flex gap-4 items-center flex-wrap">
          <RouterLink to="/register" class="btn-primary">Começar gratuitamente</RouterLink>
          <RouterLink to="/login" class="btn-ghost text-sm">Já tenho conta →</RouterLink>
        </div>
      </div>

      <!-- Mock card -->
      <div class="flex-1 flex justify-center animate-[fadeUp_0.8s_0.2s_ease_both]">
        <div class="card p-7 w-full max-w-sm shadow-[0_20px_60px_rgba(0,0,0,0.5)]">
          <div class="flex items-center gap-2.5 mb-6">
            <span class="w-2 h-2 rounded-full bg-teal shadow-[0_0_8px_#4fd1c5]"></span>
            <span class="text-muted text-xs font-medium">Sono desta semana</span>
          </div>
          <div class="flex items-end gap-2.5 h-28 mb-5">
            <div v-for="(b, i) in bars" :key="i" class="flex flex-col items-center gap-1.5 flex-1">
              <div
                class="w-full rounded-t-md bg-gradient-to-t from-accent-soft to-accent transition-all"
                :style="{ height: b.h + '%', opacity: b.active ? 1 : 0.4 }"
              ></div>
              <span class="text-muted text-[10px]">{{ b.day }}</span>
            </div>
          </div>
          <div class="flex justify-between items-center pt-4 border-t border-white/[0.06] text-xs text-muted">
            <span>Média: <strong class="text-white">7h 23min</strong></span>
            <span class="bg-teal/10 text-teal px-2.5 py-1 rounded-full font-medium">↑ 12% melhor</span>
          </div>
        </div>
      </div>
    </section>

    <!-- Features -->
    <section id="features" class="max-w-6xl mx-auto px-8 py-24">
      <p class="section-label text-center">✦ Funcionalidades</p>
      <h2 class="section-title text-center mb-16">
        Tudo que você precisa<br/>
        <span class="gradient-text">para dormir melhor</span>
      </h2>
      <div class="grid grid-cols-3 gap-5">
        <div
          v-for="f in features" :key="f.title"
          class="card p-8 hover:border-accent/30 hover:-translate-y-1 transition-all duration-300"
        >
          <div class="text-3xl mb-4">{{ f.icon }}</div>
          <h3 class="font-display font-bold mb-2">{{ f.title }}</h3>
          <p class="text-muted text-sm leading-relaxed">{{ f.desc }}</p>
        </div>
      </div>
    </section>

    <!-- CTA final -->
    <section class="max-w-xl mx-auto px-8 py-24 text-center">
      <h2 class="section-title mb-4">Pronto para <span class="gradient-text">dormir melhor?</span></h2>
      <p class="text-muted mb-8">Crie sua conta gratuitamente e comece hoje.</p>
      <RouterLink to="/register" class="btn-primary text-base px-8 py-4">Criar conta grátis →</RouterLink>
    </section>

    <footer class="border-t border-white/[0.05] py-8 text-center text-muted text-xs">
      © 2026 SleepTracker — Vue 3 + ASP.NET Core + MySQL
    </footer>
  </div>
</template>

<script setup>
import { RouterLink } from 'vue-router'
import AppNavbar from '@/components/AppNavbar.vue'

const bars = [
  { day: 'Seg', h: 65, active: false }, { day: 'Ter', h: 80, active: false },
  { day: 'Qua', h: 55, active: false }, { day: 'Qui', h: 90, active: false },
  { day: 'Sex', h: 72, active: false }, { day: 'Sáb', h: 95, active: true  },
  { day: 'Dom', h: 85, active: false },
]

const features = [
  { icon: '🌙', title: 'Registro inteligente',    desc: 'Registre horário de dormir e acordar com um toque.' },
  { icon: '📊', title: 'Análise de padrões',       desc: 'Gráficos semanais e mensais do seu sono.' },
  { icon: '🔔', title: 'Lembretes personalizados', desc: 'Alertas para sua rotina de sono ideal.' },
  { icon: '🏆', title: 'Metas e conquistas',       desc: 'Defina metas e acompanhe seu progresso.' },
  { icon: '🔒', title: 'Dados seguros',             desc: 'Criptografia JWT via API ASP.NET.' },
  { icon: '📱', title: 'Multiplataforma',           desc: 'Acesse de qualquer dispositivo.' },
]
</script>

<style>
@keyframes fadeUp {
  from { opacity: 0; transform: translateY(24px); }
  to   { opacity: 1; transform: translateY(0); }
}
</style>
