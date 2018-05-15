import Vue from 'vue'
import Router from 'vue-router'
import IndexPage from '@/pages/BW/index'
import inoutboundtable from '@/components/BW/Inoutbound/Inoutboundtable'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'IndexPage',
      component: IndexPage
    },
    {
      path: '/bw/inoutboundtable',
      name: 'inoutboundtable',
      component: inoutboundtable
    }
  ]
})
