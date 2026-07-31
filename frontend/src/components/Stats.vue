<template>
  <section id="stats" class="stats-section">
    <div class="inner">
      <div class="section-label">✦ Seu painel</div>
      <h2>Insights em tempo real<br/><span class="accent-text">via API REST</span></h2>
      <p class="sub">
        Todos os dados são consumidos diretamente da sua API ASP.NET. 
        Veja abaixo um exemplo de como os dados aparecem no painel.
      </p>

      <div class="dashboard">
        <div class="dash-card primary">
          <span class="dash-label">Média semanal</span>
          <span class="dash-val">7h 42min</span>
          <span class="dash-change up">↑ 8% vs semana passada</span>
        </div>
        <div class="dash-card">
          <span class="dash-label">Qualidade do sono</span>
          <div class="quality-bar">
            <div class="quality-fill" style="width: 82%"></div>
          </div>
          <span class="dash-val small">82 / 100</span>
        </div>
        <div class="dash-card">
          <span class="dash-label">Melhor noite</span>
          <span class="dash-val">9h 10min</span>
          <span class="dash-change neutral">Sábado, 18 mai</span>
        </div>
        <div class="dash-card">
          <span class="dash-label">Sequência atual</span>
          <span class="dash-val streak">🔥 14 dias</span>
          <span class="dash-change up">Meta: 30 dias</span>
        </div>
      </div>

      <div class="api-note">
        <code>GET /api/sleep/stats</code>
        <span>Endpoint da sua API ASP.NET — veja <strong>src/services/api.js</strong></span>
      </div>
    </div>
  </section>
</template>

<style scoped>
.stats-section {
  padding: 100px 32px;
  background: linear-gradient(180deg, transparent, var(--bg-card2) 30%, var(--bg-card2) 70%, transparent);
}

.inner {
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
  margin-bottom: 16px;
}

.accent-text {
  background: linear-gradient(135deg, var(--accent), var(--teal));
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
}

.sub {
  color: var(--text-muted);
  font-size: 0.95rem;
  max-width: 500px;
  margin: 0 auto 48px;
}

.dashboard {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  gap: 16px;
  margin-bottom: 28px;
}

.dash-card {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 16px;
  padding: 28px 24px;
  display: flex;
  flex-direction: column;
  gap: 10px;
  text-align: left;
  transition: border-color 0.3s;
}

.dash-card:hover { border-color: rgba(108,141,250,0.3); }

.dash-card.primary {
  border-color: rgba(108,141,250,0.3);
  background: linear-gradient(135deg, var(--bg-card), rgba(108,141,250,0.07));
}

.dash-label {
  font-size: 0.78rem;
  color: var(--text-muted);
  text-transform: uppercase;
  letter-spacing: 0.06em;
}

.dash-val {
  font-family: var(--font-display);
  font-size: 1.6rem;
  font-weight: 700;
  color: var(--text-primary);
}

.dash-val.small { font-size: 1.2rem; }
.streak { font-size: 1.4rem; }

.dash-change {
  font-size: 0.78rem;
}

.dash-change.up { color: var(--teal); }
.dash-change.neutral { color: var(--text-muted); }

.quality-bar {
  height: 6px;
  background: rgba(255,255,255,0.08);
  border-radius: 3px;
  overflow: hidden;
}

.quality-fill {
  height: 100%;
  background: linear-gradient(90deg, var(--accent), var(--teal));
  border-radius: 3px;
}

.api-note {
  display: inline-flex;
  align-items: center;
  gap: 16px;
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 10px;
  padding: 12px 20px;
  font-size: 0.82rem;
}

code {
  background: rgba(108,141,250,0.1);
  color: var(--accent);
  padding: 3px 10px;
  border-radius: 6px;
  font-size: 0.8rem;
}

.api-note span { color: var(--text-muted); }
.api-note strong { color: var(--text-primary); }

@media (max-width: 900px) {
  .dashboard { grid-template-columns: repeat(2, 1fr); }
}

@media (max-width: 500px) {
  .dashboard { grid-template-columns: 1fr; }
}
</style>
