<template>
    <div>
      <!--<h1>Hello App!</h1>
      <p>
        --><!-- 使用 router-link 组件来导航. --><!--
        --><!-- 通过传入 `to` 属性指定链接. --><!--
        --><!-- <router-link> 默认会被渲染成一个 `<a>` 标签 --><!--
        <router-link to="/admin/index">Go to index</router-link>
        <router-link to="/admin/home">Go to home</router-link>
      </p>-->
        <router-view></router-view>
    </div>
</template>
<script>
  export default {
  data() {
  return {

  };
  },
  mounted() {
  },
  beforeDestroy() {

  },
  methods: {

  }
  };
</script>