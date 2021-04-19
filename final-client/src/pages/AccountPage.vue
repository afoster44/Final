<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-2 mt-2">
        <img :src="account.picture" alt="">
      </div>
      <div class="col-8 mt-2">
        <h1>{{ account.name }}</h1>
        <p>Vaults: {{ }}</p>
        <p>Keeps: {{ }}</p>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Account',
  setup() {
    const state = reactive({

    })
    onMounted(() => {

    })
    return {
      account: computed(() => AppState.account),
      state
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
