<template>
  <section id="features" class="features">
    <div class="section-label">✦ Funcionalidades</div>
    <h2>Tudo que você precisa<br/><span class="accent-text">para dormir melhor</span></h2>
    <div class="grid">
      <div class="feature-card" v-for="f in features" :key="f.title">
        <div class="icon">{{ f.icon }}</div>
        <h3>{{ f.title }}</h3>
        <p>{{ f.desc }}</p>
      </div>
    </div>
  </section>
</template>

<script setup>
const features = [
  {
    icon: '🌙',
    title: 'Registro inteligente',
    desc: 'Registre horário de dormir e acordar com um toque. O app calcula automaticamente duração e qualidade.'
  },
  {
    icon: '📊',
    title: 'Análise de padrões',
    desc: 'Visualize gráficos semanais e mensais do seu sono. Identifique tendências e pontos de melhora.'
  },
  {
    icon: '🔔',
    title: 'Lembretes personalizados',
    desc: 'Configure alertas para sua rotina de sono ideal. Seja notificado na hora certa de dormir.'
  },
  {
    icon: '🏆',
    title: 'Metas e conquistas',
    desc: 'Defina metas semanais de sono e acompanhe seu progresso com um sistema de recompensas.'
  },
  {
    icon: '🔒',
    title: 'Dados seguros',
    desc: 'Seus dados são criptografados e armazenados com segurança na nossa API ASP.NET com autenticação JWT.'
  },
  {
    icon: '📱',
    title: 'Multiplataforma',
    desc: 'Acesse pelo celular, tablet ou computador. Seus dados sincronizados em tempo real via REST API.'
  },
]
</script>

<style scoped>
.features {
  padding: 100px 32px;
  max-width: 1100px;
  margin: 0 auto;
  text-align: center;
}

.section-label {
  color: var(--accent);
  font-size: 0.8rem;
  font-weight: 500;
  letter-spacing: 0.1em;
  text-transform: uppercase;
  margin-bottom: 16px;
}

h2 {
  font-family: var(--font-display);
  font-size: clamp(2rem, 4vw, 3rem);
  font-weight: 800;
  letter-spacing: -0.03em;
  line-height: 1.15;
  margin-bottom: 60px;
}

.accent-text {
  background: linear-gradient(135deg, var(--accent), var(--teal));
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
}

.grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 20px;
}

.feature-card {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 16px;
  padding: 32px 28px;
  text-align: left;
  transition: border-color 0.3s, transform 0.3s, box-shadow 0.3s;
}

.feature-card:hover {
  border-color: rgba(108,141,250,0.35);
  transform: translateY(-4px);
  box-shadow: 0 12px 40px rgba(0,0,0,0.3);
}

.icon {
  font-size: 1.8rem;
  margin-bottom: 16px;
}

h3 {
  font-family: var(--font-display);
  font-size: 1rem;
  font-weight: 700;
  margin-bottom: 10px;
  color: var(--text-primary);
}

p {
  font-size: 0.875rem;
  color: var(--text-muted);
  line-height: 1.65;
}

@media (max-width: 900px) {
  .grid { grid-template-columns: repeat(2, 1fr); }
}

@media (max-width: 600px) {
  .grid { grid-template-columns: 1fr; }
}
</style>
