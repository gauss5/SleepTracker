<template>
  <section id="cta" class="cta-section">
    <div class="inner">
      <div class="section-label">✦ Comece agora</div>
      <h2>Crie sua conta<br/><span class="accent-text">gratuitamente</span></h2>
      <p class="sub">Conectado à API ASP.NET. Seus dados ficam seguros e sincronizados.</p>

      <form class="form" @submit.prevent="handleSubmit">
        <div class="field">
          <label>Nome</label>
          <input v-model="form.name" type="text" placeholder="Seu nome completo" required />
        </div>
        <div class="field">
          <label>E-mail</label>
          <input v-model="form.email" type="email" placeholder="seu@email.com" required />
        </div>
        <div class="field">
          <label>Senha</label>
          <input v-model="form.password" type="password" placeholder="Mínimo 8 caracteres" required />
        </div>
        <button type="submit" class="btn-submit" :disabled="loading">
          <span v-if="loading">Criando conta...</span>
          <span v-else>Criar conta grátis →</span>
        </button>
        <p v-if="error" class="msg error">{{ error }}</p>
        <p v-if="success" class="msg success">✓ Conta criada com sucesso!</p>
      </form>

      <p class="terms">Ao criar uma conta, você concorda com nossos <a href="#">Termos de Uso</a>.</p>
    </div>
  </section>
</template>

<script setup>
import { ref, reactive } from 'vue'
import { authService } from '../services/api.js'

const form = reactive({ name: '', email: '', password: '' })
const loading = ref(false)
const error = ref('')
const success = ref(false)

async function handleSubmit() {
  loading.value = true
  error.value = ''
  success.value = false

  try {
    const data = await authService.register(form.name, form.email, form.password)
    // Se a API retornar token, salva automaticamente
    if (data.token) {
      localStorage.setItem('token', data.token)
    }
    success.value = true
    form.name = ''
    form.email = ''
    form.password = ''
  } catch (err) {
    error.value = err.message || 'Erro ao criar conta. Tente novamente.'
  } finally {
    loading.value = false
  }
}
</script>

<style scoped>
.cta-section {
  padding: 100px 32px 140px;
  text-align: center;
}

.inner {
  max-width: 480px;
  margin: 0 auto;
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
  margin-bottom: 12px;
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
  margin-bottom: 40px;
}

.form {
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: 20px;
  padding: 36px;
  display: flex;
  flex-direction: column;
  gap: 20px;
  text-align: left;
  margin-bottom: 20px;
}

.field {
  display: flex;
  flex-direction: column;
  gap: 8px;
}

label {
  font-size: 0.8rem;
  font-weight: 500;
  color: var(--text-muted);
  text-transform: uppercase;
  letter-spacing: 0.06em;
}

input {
  background: var(--bg-deep);
  border: 1px solid var(--border);
  border-radius: 10px;
  padding: 12px 16px;
  color: var(--text-primary);
  font-family: var(--font-body);
  font-size: 0.95rem;
  outline: none;
  transition: border-color 0.2s;
}

input::placeholder { color: var(--text-muted); opacity: 0.6; }

input:focus {
  border-color: var(--accent);
  box-shadow: 0 0 0 3px rgba(108,141,250,0.1);
}

.btn-submit {
  background: var(--accent);
  color: #fff;
  border: none;
  border-radius: 10px;
  padding: 14px;
  font-family: var(--font-body);
  font-size: 0.95rem;
  font-weight: 500;
  cursor: pointer;
  transition: background 0.2s, transform 0.2s, box-shadow 0.2s;
  box-shadow: 0 0 30px rgba(108,141,250,0.3);
}

.btn-submit:hover:not(:disabled) {
  background: var(--accent-soft);
  transform: translateY(-2px);
}

.btn-submit:disabled {
  opacity: 0.6;
  cursor: not-allowed;
}

.msg {
  text-align: center;
  font-size: 0.875rem;
  padding: 10px;
  border-radius: 8px;
}

.msg.error {
  color: #f87171;
  background: rgba(248,113,113,0.1);
}

.msg.success {
  color: var(--teal);
  background: rgba(79,209,197,0.1);
}

.terms {
  font-size: 0.78rem;
  color: var(--text-muted);
}

.terms a {
  color: var(--accent);
  text-decoration: none;
}
</style>
