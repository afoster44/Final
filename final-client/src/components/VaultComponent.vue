<template>
  <div class="vault-component col-2">
    <div class="card">
      <div class="card-title">
        <h3>{{ vault.name }}</h3>
      </div>
      <div class="card-text">
        {{ vault.description }}
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'VaultComponent',
  props: {
    vault: { type: Object, required: true }
  },
  setup() {
    return {}
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
