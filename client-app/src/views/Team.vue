<template>
  <div class="about">
    <h1 class="subtitle-1 grey--text">Team</h1>
    <v-container class="my-5">
      <v-row>
        <v-flex xs12 sm6 md4 lg3 v-for="person in team" :key="person.name">
          <v-card class="text-center ma-3">
            <v-responsive class="pt-5">
              <v-avatar size="100" class="lighten-2">
              <v-img :src="person.img"></v-img>
            </v-avatar>
            </v-responsive>
            <v-card-text>
              <div class="subheading">{{person.name}}</div>
              <div class="grey--text">{{person.role}}</div>
            </v-card-text>
            <v-card-actions class="text-center">
                <v-btn elevation="0"  color="white">
                  <v-icon>message</v-icon>
                  <span>Message</span>
                </v-btn>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-row>
    </v-container>
  </div>
</template>
<script>
export default {
  data(){
    return {
      team: [
        { name: 'The Net Ninja', role: 'Web developer', img :'/avatar-1.png' },
        { name: 'Ryu', role: 'Graphic designer' ,img :'/avatar-2.png'},
        { name: 'Chun Li', role: 'Web developer' ,img :'/avatar-3.png'},
        { name: 'Gouken', role: 'Social media maverick' ,img :'/avatar-4.png'},
        { name: 'Yoshi', role: 'Sales guru',img :'/avatar-5.png'}
      ]
    }
  }
}
</script>