<template>
  <div>
    <div id="main">
      <div class="container">
        <div class="row">
          <div class="col-md">
            <AppItemList title="Prefixos" v-bind:items="prefixes" v-on:addItem="addPrefix" v-on:removeItem="removePrefix"></AppItemList>
          </div>
          <div class="col-md">
            <AppItemList title="Sufixos" v-bind:items="sufixes" v-on:addItem="addSufix" v-on:removeItem="removeSufix"></AppItemList>
         </div>
        </div>
         <br/>
         <h5>Domains <span class="badge badge-info">{{domains.length}}</span></h5>
          <div class="card">
              <div class="card-body">
                <ul class="list-group">
                  <li class="list-group-item" v-for="domain in domains" v-bind:key="domain.name">
                    <div class="row">
                      <div class="col-md">
                        {{domain.name}}
                      </div>
                      <div class="col-md text-right">
                        <a class="btn btn-info" v-bind:href="domain.checkout" target="_blank">
                          <span class="fa fa-shopping-cart"></span>
                        </a>
                      </div>
                    </div>
                  </li>
                </ul>
              </div>
            </div>
        </div>
    </div>
  </div>
</template>

<script>
import "bootstrap/dist/css/bootstrap.css";
import "font-awesome/css/font-awesome.css";
import AppItemList from "./AppItemList";
import axios from "axios/dist/axios";

export default {
  name: "App",
  components: { AppItemList },
  data : function(){ //isso afeta diretamente o computed
    return {
      prefixes: [],
      sufixes: [],
    }
  },

  methods : {
    addPrefix : function(e){
      this.prefixes.push(e);
    },
    addSufix : function(e){
      this.sufixes.push(e);
    },
    removePrefix : function(e){
      this.prefixes.splice(this.prefixes.indexOf(e),1);
    },
    removeSufix : function(e){
      this.sufixes.splice(this.sufixes.indexOf(e),1);
    }
  },
 /* created(){ // Quando os componentes já foram criados, posso usar para pesquisar no backend. no beforeCreated() o componente não existe ainda.
    this.domains = this.generate();
  },*/
  computed : { //sempre que prefixes e sufixes for alterado, como sufix e prefix não é computado não chama
    domains(){
     const lstDomains = [];
      for(const p of this.prefixes){
        for(const s of this.sufixes){
          const name = p + s;
          const url = name.toLowerCase();
          const checkout = `https://checkout.hostgator.com.br/?a=add&sld=${url}&tld=.website`;
          lstDomains.push({name, checkout});
        }
      }
      return lstDomains;
    }
  },

  created(){
    axios({
      url: "http://localhost:5000/v1/Item",
      method: "get"
    }).then(obj => {
      this.prefixes = obj.data.filter(x => x.sTipo == "prefixo").map(y => y = y.sId);
      this.sufixes = obj.data.filter(x=> x.sTipo == "sufixo").map(y => y = y.sId);
    });
  }
    
};
</script>