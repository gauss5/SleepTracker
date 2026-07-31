<template>
  <section class="hero">
    <div class="hero-bg">
      <div class="orb orb1"></div>
      <div class="orb orb2"></div>
      <div class="stars"></div>
    </div>
    <div class="hero-content">
      <span class="badge">✦ Monitore seu sono com inteligência</span>
      <h1>Durma melhor.<br/><span class="accent-text">Viva melhor.</span></h1>
      <p class="hero-sub">
        Registre, analise e melhore seus padrões de sono com dados precisos e insights personalizados. 
        Conectado direto à sua conta, em tempo real.
      </p>
      <div class="hero-actions">
        <a href="#cta" class="btn-primary">Começar gratuitamente</a>
        <a href="#features" class="btn-ghost">Ver recursos →</a>
      </div>
      <div class="hero-stats">
        <div class="stat" v-for="s in stats" :key="s.label">
          <span class="stat-val">{{ s.value }}</span>
          <span class="stat-label">{{ s.label }}</span>
        </div>
      </div>
    </div>
    <div class="hero-visual">
      <div class="card-mock">
        <div class="card-header">
          <span class="dot green"></span>
          <span class="card-title">Sono desta semana</span>
        </div>
        <div class="chart-bars">
          <div v-for="(bar, i) in bars" :key="i" class="bar-wrap">
            <div class="bar" :style="{ height: bar.h + '%', opacity: bar.active ? 1 : 0.4 }"></div>
            <span class="bar-label">{{ bar.day }}</span>
          </div>
        </div>
        <div class="card-footer">
          <span>Média: <strong>7h 23min</strong></span>
          <span class="tag-good">↑ 12% melhor</span>
        </div>
      </div>
    </div>
  </section>
</template>

<script setup>
const stats = [
  { value: '10k+', label: 'Usuários ativos' },
  { value: '98%', label: 'Satisfação' },
  { value: '4.9★', label: 'Avaliação' },
]

const bars = [
  { day: 'Seg', h: 65, active: false },
  { day: 'Ter', h: 80, active: false },
  { day: 'Qua', h: 55, active: false },
  { day: 'Qui', h: 90, active: false },
  { day: 'Sex', h: 72, active: false },
  { day: 'Sáb', h: 95, active: true },
  { day: 'Dom', h: 85, active: false },
]
</script>

<style scoped>
.hero {
  min-height: 100vh;
  display: flex;
  align-items: center;
  padding: 120px 32px 80px;
  max-width: 1100px;
  margin: 0 auto;
  gap: 60px;
  position: relative;
}

.hero-bg {
  position: fixed;
  inset: 0;
  pointer-events: none;
  z-index: 0;
}

.orb {
  position: absolute;
  border-radius: 50%;
  filter: blur(80px);
}

.orb1 {
  width: 500px; height: 500px;
  background: radial-gradient(circle, rgba(108,141,250,0.15), transparent 70%);
  top: -100px; left: -100px;
}

.orb2 {
  width: 400px; height: 400px;
  background: radial-gradient(circle, rgba(79,209,197,0.1), transparent 70%);
  bottom: 0; right: 0;
}

.hero-content {
  flex: 1;
  position: relative;
  z-index: 1;
  animation: fadeUp 0.8s ease both;
}

.hero-visual {
  flex: 1;
  display: flex;
  justify-content: center;
  position: relative;
  z-index: 1;
  animation: fadeUp 0.8s 0.2s ease both;
}

.badge {
  display: inline-block;
  background: var(--accent-glow);
  border: 1px solid var(--border);
  color: var(--accent);
  font-size: 0.8rem;
  font-weight: 500;
  padding: 6px 16px;
  border-radius: 100px;
  margin-bottom: 24px;
  letter-spacing: 0.02em;
}

h1 {
  font-family: var(--font-display);
  font-size: clamp(2.5rem, 5vw, 3.8rem);
  font-weight: 800;
  line-height: 1.1;
  letter-spacing: -0.03em;
  margin-bottom: 20px;
}

.accent-text {
  background: linear-gradient(135deg, var(--accent), var(--teal));
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
}

.hero-sub {
  color: var(--text-muted);
  font-size: 1.05rem;
  max-width: 480px;
  margin-bottom: 36px;
  line-height: 1.7;
}

.hero-actions {
  display: flex;
  gap: 16px;
  align-items: center;
  margin-bottom: 48px;
  flex-wrap: wrap;
}

.btn-primary {
  background: var(--accent);
  color: #fff;
  text-decoration: none;
  padding: 14px 28px;
  border-radius: 10px;
  font-weight: 500;
  font-size: 0.95rem;
  transition: background 0.2s, transform 0.2s, box-shadow 0.2s;
  box-shadow: 0 0 30px rgba(108,141,250,0.3);
}

.btn-primary:hover {
  background: var(--accent-soft);
  transform: translateY(-2px);
  box-shadow: 0 0 40px rgba(108,141,250,0.45);
}

.btn-ghost {
  color: var(--text-muted);
  text-decoration: none;
  font-size: 0.95rem;
  transition: color 0.2s;
}

.btn-ghost:hover { color: var(--text-primary); }

.hero-stats {
  display: flex;
  gap: 36px;
}

.stat {
  display: flex;
  flex-direction: column;
  gap: 2px;
}

.stat-val {
  font-family: var(--font-display);
  font-size: 1.4rem;
  font-weight: 700;
  color: var(--text-primary);
}

.stat-label {
  font-size: 0.8rem;
  color: var(--text-muted);
}

/* ── Card mock ── */
.card-mock {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 20px;
  padding: 28px;
  width: 100%;
  max-width: 340px;
  box-shadow: 0 20px 60px rgba(0,0,0,0.5), 0 0 0 1px rgba(108,141,250,0.06);
}

.card-header {
  display: flex;
  align-items: center;
  gap: 10px;
  margin-bottom: 24px;
}

.dot {
  width: 8px; height: 8px;
  border-radius: 50%;
}

.dot.green { background: var(--teal); box-shadow: 0 0 8px var(--teal); }

.card-title {
  font-size: 0.85rem;
  font-weight: 500;
  color: var(--text-muted);
}

.chart-bars {
  display: flex;
  align-items: flex-end;
  gap: 10px;
  height: 120px;
  margin-bottom: 20px;
}

.bar-wrap {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 6px;
  flex: 1;
}

.bar {
  width: 100%;
  background: linear-gradient(180deg, var(--accent), var(--accent-soft));
  border-radius: 6px 6px 0 0;
  transition: height 1s ease;
}

.bar-label {
  font-size: 0.7rem;
  color: var(--text-muted);
}

.card-footer {
  display: flex;
  justify-content: space-between;
  align-items: center;
  font-size: 0.82rem;
  color: var(--text-muted);
  padding-top: 16px;
  border-top: 1px solid var(--border);
}

.card-footer strong { color: var(--text-primary); }

.tag-good {
  background: rgba(79,209,197,0.12);
  color: var(--teal);
  padding: 3px 10px;
  border-radius: 100px;
  font-size: 0.75rem;
  font-weight: 500;
}

@keyframes fadeUp {
  from { opacity: 0; transform: translateY(24px); }
  to   { opacity: 1; transform: translateY(0); }
}

@media (max-width: 768px) {
  .hero { flex-direction: column; padding-top: 100px; }
  .hero-visual { width: 100%; }
}
</style>
