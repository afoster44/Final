<template>
  <div class="VaultDropdownComponent">
    <a class="dropdown-item" href="#" @click.prevent="addKeepToVault">
      {{ vault.name }}
    </a>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { vaultKeepService } from '../services/VaultKeepService'
export default {
  name: 'VaultDropdownComponent',
  props: {
    vault: { type: Object, required: true }
  },
  setup(props) {
    const state = reactive({
      keep: computed(() => AppState.activeKeep)
    })
    return {
      state,
      async addKeepToVault() {
        const vaultKeep = {
          vaultId: props.vault.id,
          keepId: state.keep.id
        }
        await vaultKeepService.addKeepToVault(vaultKeep)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
