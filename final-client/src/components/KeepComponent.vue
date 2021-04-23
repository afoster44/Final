<template>
  <div class="keep-component card-container">
    <div class="card img-fluid" v-if="keep">
      <img class="card-img-top" :src="keep.img">
      <div class="card-img-overlay">
        <!-- <span aria-hidden="true" class="mr-1" data-dismiss="modal">&times;</span> -->
        <p class="text-strong" data-toggle="modal" data-target="#keepModal" @click="popKeepModal">
          {{ keep.name }}
        </p>
        <router-link :to="{name: 'ProfilePage', params: {id: keep.creatorId}}">
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
        keepService.getKeepById(props.keep.id)
      }
    }
  },
  components: {}
}
</script>

<style scoped lang="scss">
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
.card{
  box-shadow: 2px 2px 2px #04202C;
}
</style>
