<template>
  <div>
    <div id="slogan">
      <div class="text-center">
        <h1>NameGator</h1>
        <br />
        <h6 class="text-secondary">Gerador de nomes aleatórios usando Vue.JS, Axios, .Net Core e Entity Framework</h6>
      </div>
    </div>
    <div id="main">
      <DomainList></DomainList>
    </div>
  </div>
</template>

<script>
import "bootstrap/dist/css/bootstrap.css";
import "font-awesome/css/font-awesome.css";
import DomainList from "./components/DomainList";

export default {
  name: "App",
  components: { DomainList },
};
</script>

<style>
#slogan {
  margin-top: 30px;
  margin-bottom: 30px;
}

#main {
  background: #f1f1f1;
  padding-top: 30px;
  padding-bottom: 30px;
}
</style>
