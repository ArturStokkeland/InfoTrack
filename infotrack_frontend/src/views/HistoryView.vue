<script setup>
import { ref, onMounted } from "vue";

const result = ref("");
const loading = ref(false);
const errorMessage = ref("");

onMounted(() => {
  loading.value = true;
  errorMessage.value = "";
  result.value = "";

  fetch("https://localhost:7244/history")
    .then((response) => response.json())
    .then((data) => {
      let resultArray = [];
      for (let i = 0; i < data.length; i++) {
        let date = new Date(data[i].dateSearched);
        let myObject = {
          id: data[i].id,
          searchTerm: data[i].searchTerm,
          searchEngine: data[i].searchEngine,
          rankings: data[i].rankings,
          dateSearched: date.toLocaleString(),
        };
        resultArray.push(myObject);
      }
      result.value = resultArray;
      console.log(resultArray);
      console.log(result.value);
      loading.value = false;
    })
    .catch((error) => {
      console.log(error);
      errorMessage.value = "Error: " + error.message;
      loading.value = false;
    });
});
</script>

<template>
  <div class="box">
    <h1>Result</h1>
    <p v-if="loading">Getting data, please wait...</p>
    <p v-if="!loading && !result">
      Something went wrong, or there is not history.
    </p>
    <div v-if="!loading && result">
      <div class="grid-header">
        <p class="grid-header-item">Rankings:</p>
        <p class="grid-header-item">Search Term</p>
        <p class="grid-header-item">Search Engine</p>
        <p class="grid-header-item">Date:</p>
      </div>
      <dib class="grid-body" v-for="item in result" :key="item.id">
        <p class="grid-body-item">{{ item.rankings }}</p>
        <p class="grid-body-item">{{ item.searchTerm }}</p>
        <p class="grid-body-item">{{ item.searchEngine }}</p>
        <p class="grid-body-item">{{ item.dateSearched }}</p>
      </dib>
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

.grid-header {
  width: 100%;
  display: grid;
  grid-template-columns: repeat(4, minmax(0, 1fr));
  gap: 1rem;
}

.grid-header-item {
  font-size: 1.5rem;
  font-weight: bold;
  text-align: center;
}

.grid-body {
  width: 100%;
  display: grid;
  grid-template-columns: repeat(4, minmax(0, 1fr));
  gap: 1rem;
  margin-bottom: 10px;
  background-color: #eee;
  border-radius: 20px;
}

.grid-body:hover {
  background-color: #ddd;
}

.grid-body-item {
  font-size: 1.25rem;
  text-align: center;
}
</style>
