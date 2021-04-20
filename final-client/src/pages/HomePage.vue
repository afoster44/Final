<template>
  <div class="home container-fluid">
    <div class="card-columns">
      <div class="card-container">
        <KeepComponent v-for="keep in state.keeps" :key="keep.id" :keep="keep" />
      </div>
    </div>

    <!-- <KeepDisplayModal /> -->
  </div>
</template>

<script>
import { reactive, computed } from '@vue/reactivity'
import { onMounted } from '@vue/runtime-core'
import { keepService } from '../services/KeepService'
import { AppState } from '../AppState'
export default {
  name: 'Home',
  setup() {
    const state = reactive({
      keeps: computed(() => AppState.keeps)
    })
    onMounted(() => {
      keepService.getKeeps()
    })
    return {
      state
    }
  }
}
</script>

<style scoped lang="scss">
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
