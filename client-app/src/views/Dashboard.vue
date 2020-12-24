<template>
  <div class="home">
    <h1 class="subtitle-1 grey--text">Dashboard</h1>
    <v-container class="my-5">
      <v-row class="ma-3">
         <v-tooltip top>
          <template v-slot:activator="{ on }">
            <v-btn small elevation="0" @click="sortBy('title')" v-on="on">
              <v-icon left small>folder</v-icon>
              <span right class="caption text-lowercase">by project name</span>
            </v-btn>
          </template>
          <span>Sorts projects by name</span>
        </v-tooltip>
        
        <v-tooltip top>
         <template v-slot:activator="{ on }">
            <v-btn elevation="0" small @click="sortBy('person')" v-on="on">
              <v-icon left small>person</v-icon>
              <span class="caption text-lowercase">By Person</span>
            </v-btn>
         </template>
         <span>Sorts projects by person</span>
        </v-tooltip>
       
      </v-row>
      <v-card flat class="ps-3" v-for="project in projects" :key="project.title">
        <v-row  :class="`pa-3 project ${project.status}`" >
          <v-flex xs12 md6>
            <div class="caption grey--text">Project Title</div>
             <div >{{project.title}}</div>
          </v-flex>
          <v-flex xs6 sm4 md2>
            <div class="caption grey--text">Person</div>
             <div >{{project.person}}</div>
          </v-flex>
          <v-flex xs6 sm4 md2>
            <div class="caption grey--text">Due by</div>
             <div >{{project.due}}</div>
          </v-flex>
            <v-flex xs2 sm4 md2>
              <div align="right" class="pr-12">
                <v-chip small :class="`${project.status} right white--text caption my-2`">
                  {{project.status}}
                </v-chip>
            </div>
          </v-flex>
        </v-row>
         <v-row cols="12">
        <v-divider></v-divider>
        </v-row>
      </v-card>
    </v-container>
  </div>
</template>

<script>
// @ is an alias to /src

export default {
  data () {
    return {
      projects: [
        { title: 'Design a new website', person: 'The Net Ninja', due: '1st Jan 2019', status: 'ongoing', content: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Sunt consequuntur eos eligendi illum minima adipisci deleniti, dicta mollitia enim explicabo fugiat quidem ducimus praesentium voluptates porro molestias non sequi animi!'},
        { title: 'Code up the homepage', person: 'Chun Li', due: '10th Jan 2019', status: 'complete', content: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Sunt consequuntur eos eligendi illum minima adipisci deleniti, dicta mollitia enim explicabo fugiat quidem ducimus praesentium voluptates porro molestias non sequi animi!'},
        { title: 'Design video thumbnails', person: 'Ryu', due: '20th Dec 2018', status: 'complete', content: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Sunt consequuntur eos eligendi illum minima adipisci deleniti, dicta mollitia enim explicabo fugiat quidem ducimus praesentium voluptates porro molestias non sequi animi!'},
        { title: 'Create a community forum', person: 'Gouken', due: '20th Oct 2018', status: 'overdue', content: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Sunt consequuntur eos eligendi illum minima adipisci deleniti, dicta mollitia enim explicabo fugiat quidem ducimus praesentium voluptates porro molestias non sequi animi!'},
      ]
    }
  },
  methods: {
    sortBy(prod){
      this.projects.sort((a,b)=>a[prod]<b[prod]?-1:1);
    }
  }
}
</script>
<style scoped>
.project.ongoing{
  border-left: 3px solid #3cd1c2;
}
.project.complete{
  border-left: 3px solid orange;
}
.project.overdue{
  border-left: 3px solid tomato;
}
.v-chip.ongoing{
  background:  #3cd1c2 !important;;
}
.v-chip.complete{
  background: orange !important;;
}
.v-chip.overdue{
  background:tomato !important;;
}
.v-card{
    word-break: normal;
  }
</style>>
