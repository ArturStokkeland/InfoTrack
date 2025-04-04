<script setup>
import { ref } from "vue";
const result = ref("");
const loading = ref(false);
const errorMessage = ref("");
const searchTerm = ref("");
const searchEngine = ref("google");

function search() {
  loading.value = true;
  errorMessage.value = "";
  result.value = "";

  const options = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({
      searchTerm: searchTerm.value,
      searchEngine: searchEngine.value,
    }),
  };

  fetch("https://localhost:7203/scrape", options)
    .then((response) => response.json())
    .then((data) => {
      result.value = {
        searchTerm: data.searchTerm,
        searchEngine: data.searchEngine,
        rankings: data.rankings,
      };
      console.log(result.value);
      loading.value = false;
    })
    .catch((error) => {
      console.log(error);
      errorMessage.value = "Error: " + error.message;
      loading.value = false;
    });
}
</script>

<template>
  <div class="box">
    <h1>Search</h1>
    <div id="inputs">
      <input type="text" v-model="searchTerm" placeholder="Search term" />
      <select v-model="searchEngine">
        <option value="google">Google</option>
        <option value="bing">Bing</option>
      </select>
    </div>
    <button @click="search()">Search</button>
  </div>

  <div class="box">
    <h1>Result</h1>
    <div v-if="!result && !loading">
      <p>No result yet, try searching</p>
    </div>
    <div v-if="loading"><p>Searching, please wait...</p></div>
    <div v-if="errorMessage && !loading">
      <p>{{ errorMessage }}</p>
    </div>
    <div v-if="result && !loading">
      <div id="result">
        <div id="resultHeaders">
          <p>Search term:</p>
          <p>Search Engine:</p>
          <p>Rankings:</p>
        </div>
        <div>
          <p>
            {{ result.searchTerm }}
          </p>
          <p>{{ result.searchEngine }}</p>
          <p>{{ result.rankings }}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.box {
  display: flex;
  flex-direction: column;
  gap: 20px;
  padding: 20px;
  margin: 20px auto;
  border: 1px solid #ccc;
  border-radius: 5px;
  box-shadow: 0 4px 6px -1px rgb(0 0 0 / 0.1), 0 2px 4px -2px rgb(0 0 0 / 0.1);
  max-width: 1200px;
}

h1 {
  margin: 0;
}

#inputs {
  display: flex;
  font-size: 2rem;
}

input {
  border: 1px solid #000;
  border-top-left-radius: 5px;
  border-bottom-left-radius: 5px;
  flex: 1;
  font-size: 1.5rem;
  padding: 10px;
  padding-left: 20px;
}

select {
  background-color: #eee;
  border: 1px solid #000;
  border-left: none;
  border-top-right-radius: 5px;
  border-bottom-right-radius: 5px;
  font-size: 1.5rem;
  padding: 10px;
  padding-right: 20px;
}

input:focus,
select:focus {
  outline: none;
}

button {
  background-color: #0696b7;
  border: none;
  color: #fff;
  padding: 10px 20px;
  font-size: 1.5rem;
}

button:hover {
  background-color: #17a7c8;
  cursor: pointer;
}

#result {
  display: flex;
  justify-content: center;
  gap: 10px;
  text-align: left;
}

#resultHeaders {
  font-weight: bold;
}
</style>
