<template>
  <div class="home flex-grow-1 container-fluid">
    <img src="https://bcw.blob.core.windows.net/public/img/8600856373152463" alt="CodeWorks Logo">
    <h1 class="my-5 bg-dark text-light p-3 rounded d-flex align-items-center">
      <span class="mx-2 text-white">Vue 3 Starter</span>
    </h1>
    <!-- <p>{{ state.keeps }}</p> -->
    <div class="row">
      <KeepComponent v-for="keep in state.keeps" :key="keep.id" :keep="keep" />
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
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
