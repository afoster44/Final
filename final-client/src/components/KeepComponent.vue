<template>
  <div class="keep-component col-4" data-toggle="modal" data-target="#keepModal" @click="popKeepModal">
    <div class="card img-fluid">
      <img class="card-img-top" :src="keep.img">
      <div class="card-img-overlay">
        <p class="text-light">
          {{ keep.name }}
        </p>
        <router-link data-toggle="modal" data-dismiss="modal" :to="{name: 'ProfilePage', params: {id: keep.creatorId}}">
          <i class="fa fa-user text-light mr-3 mb-3" aria-hidden="true"></i>
        </router-link>
      </div>
    </div>
    <KeepDisplayModal />
  </div>
</template>

<script>
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
export default {
  name: 'KeepComponent',
  props: {
    keep: { type: Object, required: true }
  },
  setup(props) {
    return {
      popKeepModal() {
        AppState.activeKeep = props.keep
        // we are passing the whole keep here because every time this modal pops we need to increase the view by one
        keepService.editKeep(props.keep)
      }
    }
  },
  components: {}
}
</script>

<style scoped>
div{
  height: 100%
}
p{
  position: absolute;
  bottom: 0;
}
i{
  position: absolute;
  bottom: 0;
  right: 0;
}
</style>
