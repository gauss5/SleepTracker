<template>
  <footer class="footer">
    <div class="inner">
      <div class="brand">
        <svg width="22" height="22" viewBox="0 0 28 28" fill="none">
          <circle cx="14" cy="14" r="13" stroke="var(--accent)" stroke-width="1.5"/>
          <path d="M14 6C10 6 7 9.5 7 14c0 3.9 2.5 7.2 6 8.5V14l5-5.5C16.8 6.9 15.5 6 14 6z" fill="var(--accent)" opacity="0.9"/>
        </svg>
        <span>SleepTracker</span>
      </div>
      <p class="copy">© 2026 SleepTracker. Feito com Vue 3 + ASP.NET.</p>
    </div>
  </footer>
</template>

<style scoped>
.footer {
  border-top: 1px solid var(--border);
  padding: 32px;
}

.inner {
  max-width: 1100px;
  margin: 0 auto;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.brand {
  display: flex;
  align-items: center;
  gap: 8px;
  font-family: var(--font-display);
  font-weight: 700;
  font-size: 0.9rem;
  color: var(--text-primary);
}

.copy {
  font-size: 0.8rem;
  color: var(--text-muted);
}
</style>
