<template>
    <div class="main">{{title}} Hated</div>
</template>

<script>
    export default {
        name: 'Hated',
        data: () => ({
            title: 'Witaj'
        })
    }

</script>

<style lang="scss">
    .main {
        text-align: center;
        flex: 1;
        margin-top: 40px;
        font-size: 2em;
    }

</style>
