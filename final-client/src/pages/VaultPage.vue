<template>
  <div class="vault-page container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>{{ state.vault.name }}</h1>
      </div>
    </div>
    <div class="row">
      <div class="col-1">
        Keeps: {{ state.vaultKeeps.length }}
      </div>
      <div class="col-10">
        <div class="col-3">
          <div class="dropdown">
            <div v-if="state.account.id === state.vault.creatorId ">
              <button class="btn btn-secondary dropdown-toggle"
                      type="button"
                      id="dropdownMenuButton"
                      data-toggle="dropdown"
                      aria-haspopup="true"
                      aria-expanded="false"
              >
                Vaults here
              </button>

              <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                <VaultKeepDropdownComponent v-for="vaultKeep in state.vaultKeeps" :key="vaultKeep.id" :vault-keep="vaultKeep" :vault="state.vault" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="card-columns">
      <KeepComponent v-for="keep in state.vaultKeeps" :key="keep" :keep="keep" />
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed, onMounted } from '@vue/runtime-core'
import { vaultService } from '../services/VaultService'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
export default {
  name: 'VaultPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      vaultKeeps: computed(() => AppState.vaultKeeps),
      vault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account)
    })
    onMounted(() => {
      vaultService.getKeepsByVaultId(route.params.id)
      vaultService.getVaultsById(route.params.id)
    })
    return { state }
  },
  components: {}
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
