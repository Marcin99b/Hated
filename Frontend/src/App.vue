<template>
    <div id="app">
        <router-view/>
    </div>
</template>

<script>
    export default {
        name: 'App'
    }

</script>

<style>
    * {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
        outline: none;
    }

    body {
        font-family: Arial, "Helvetica Neue", Helvetica, sans-serif;
        line-height: 1;
        font-size: 14px;
        font-weight: 300;
        overflow: hidden;
    }

    #app {
        display: flex;
        height: 100vh;
        width: 100vw;
        overflow: hidden;
    }

</style>
