<template>
  <div>
    <HomeNavBar v-if="checkRoute"></HomeNavBar>
    <MainNavBar v-else></MainNavBar>
  </div>
</template>

<script>
import HomeNavBar from '@/components/NavBar/HomeNavBar.vue'
import MainNavBar from '@/components/NavBar/MainNavBar.vue'
import axios from 'axios'
export default {
  name: 'NavBar',
  components: {
    'HomeNavBar': HomeNavBar,
    'MainNavBar': MainNavBar
  },
  computed: {
    checkRoute: function () {
      return this.$route.name === 'Home' || this.$route.name === 'Registration' || this.$route.name === 'ResetPassword' || this.$route.name === 'NotFound'
    }
  },
  mounted: function () {
    setInterval(this.refreshToken, 900000)// every 15 mins
  },
  methods: {
    refreshToken: function () {
      if (this.checkRoute === false) {
        axios({
          method: 'POST',
          url: 'http://localhost/server/v1/TokenRefresh/Refresh',
          headers: this.$store.getters.getheader,
          data: {
            Username: this.$store.getters.getusername,
            Token: this.$store.getters.gettoken
          }
        })
          .then((response) => {
            console.log(response)
            this.$store.dispatch('acttoken', {Token: response.data.token})
            this.$store.dispatch('actheadertoken', {TokenHeader: response.data.token})
          })
          .catch((error) => {
            console.log(error)
          })
      }
    }
  }
}
</script>

<style>
</style>
