<template>
  <div class="vault-component col-3">
    <div class="card">
      <div class="card-title">
        <div v-if="state.account">
          <h3>{{ vault.name }} <i class="fa fa-trash" aria-hidden="true" @click="deleteVault" v-if="state.account.id === vault.creatorId"></i></h3>
        </div>
      </div>
      <div class="card-text">
        {{ vault.description }}
      </div>
    </div>
  </div>
</template>

<script>
import { vaultService } from '../services/VaultService'
import { useRoute } from 'vue-router'
import { reactive } from '@vue/reactivity'
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'

export default {
  name: 'VaultComponent',
  props: {
    vault: { type: Object, required: true }
  },
  setup(props) {
    const route = useRoute()
    const state = reactive({
      account: computed(() => AppState.account)
    })
    return {
      state,
      route,
      deleteVault() {
        vaultService.deleteVault(props.vault.id, route.params.id)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
