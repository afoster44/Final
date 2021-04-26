<template>
  <div class="container-fluid bg-light">
    <div class="row">
      <div class="col-sm-2 mt-2">
        <img :src="state.account.picture" alt="">
      </div>
      <div class="col-sm-8 mt-2">
        <h1>{{ state.account.name }}</h1>
        <p>Vaults: {{ state.vaults.length }}</p>
        <p>Keeps: {{ state.keeps.length }}</p>
      </div>
    </div>
    <div class="row">
      <div class="col-2">
        <p>Vaults:</p>
      </div>
      <div class="col-10">
        <CreateVaultModal />
      </div>
    </div>
    <div class="row">
      <div class="card-columns">
        <VaultComponent v-for="vault in state.vaults" :key="vault.id" :vault="vault" />
      </div>
    </div>
    <div class="row">
      <div class="col-2">
        Keeps:
      </div>
      <div class="col-10">
        <CreateKeepModal />
      </div>
    </div>
    <div class="card-columns">
      <KeepComponent v-for="keep in state.keeps" :key="keep.id" :keep="keep" />
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
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.accountVaults),
      keeps: computed(() => AppState.accountKeeps)
    })
    onMounted(() => {
    })
    return {
      state
    }
  }
}
</script>

<style lang="scss" scoped>
.card-columns {
  @media(max-width: 767px) {
    column-count: 2;
  }
  @media(min-width: 768px) {
    column-count: 3;
  }
  @media(min-width: 1200px) {
    column-count: 4;
  }
}
</style>
