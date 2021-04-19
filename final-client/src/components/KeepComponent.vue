<template>
  <div class="keep-component col-4">
    <div class="card img-fluid">
      <img class="card-img-top" :src="keep.img">
      <div class="card-img-overlay">
        <p class="text-light">
          {{ keep.name }}
        </p>
        <router-link :to="{name: 'ProfilePage', params: {id: keep.creatorId}}">
          <i class="fa fa-user text-light mr-3 mb-3" aria-hidden="true"></i>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'KeepComponent',
  props: {
    keep: { type: Object, required: true }
  },
  setup() {
    return {

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
