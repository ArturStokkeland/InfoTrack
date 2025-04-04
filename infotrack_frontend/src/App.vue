<template>
  <nav>
    <router-link to="/">Search</router-link> |
    <router-link to="/history">History</router-link>
  </nav>
  <router-view />
</template>

<style>
body {
  padding: 0;
  margin: 0;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #023e5c;
}

nav {
  background-color: #0696b7;
  color: #fff;
  font-size: 1.5rem;
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #fff;
  text-decoration: none;
}

nav a.router-link-exact-active {
  color: #faa41a;
}
</style>
