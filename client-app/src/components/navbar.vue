<template>
    <nav v-if="checkAuth()">
        <v-app-bar app flat>
            <v-app-bar-nav-icon class="grey--text" @click="drawer = !drawer"></v-app-bar-nav-icon>
            <v-toolbar-title class="text-uppercase grey--text">
                <span class="font-weight-light">Tadu</span>
                <span>Vue</span>
            </v-toolbar-title>
            <v-spacer></v-spacer>
            <div class="text-center">
                <v-menu offset-y>
                    <template v-slot:activator="{ on, attrs }">
                        <v-btn
                        v-bind="attrs"
                        v-on="on"
                        elevation="0"
                        >
                        <v-icon left>expand_more</v-icon>
                        Menu
                        </v-btn>
                    </template>
                    <v-list>
                        <v-list-item
                        v-for="(item, index) in links"
                        :key="index" router :to="item.route"
                        >
                        <v-list-item-title>{{ item.text }}</v-list-item-title>
                        </v-list-item>
                    </v-list>
                    </v-menu>
                </div>
            <v-btn elevation="0" @click="logout">
                <span>Sign Out</span>
                <v-icon right>exit_to_app</v-icon>
            </v-btn>
        </v-app-bar>
        <v-navigation-drawer app v-model="drawer" class="indigo">
            <v-row justify="center">
                <v-col cols="6" class="mt-5">
                    <v-avatar  size="100">
                        <img src="/avatar-1.png" alt="">
                    </v-avatar>
                </v-col>
            </v-row>
             <v-row justify="center">
                 <Popup/>
             </v-row>
            <v-list>
                <v-list-item v-for="link in links" :key="link.text" route :to="link.route">
                    <v-list-item-icon>
                        <v-icon class="white--text" v-text="link.icon"></v-icon>
                    </v-list-item-icon>
                    <v-list-item-content>
                            <v-list-item-title class="white--text">{{ link.text }}</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>
            </v-list>
        </v-navigation-drawer>
    </nav>
</template>
<script>
import Popup from './Popup';
export default {
    props:{
        auth:Boolean
    },
    data() {
        return {
            drawer : false,
            links :  [
                { icon: 'mdi-view-dashboard', text: 'Dashboard', route: '/' },
                { icon: 'mdi-folder', text: 'My Projects', route: '/projects' },
                { icon: 'mdi-account', text: 'Team', route: '/team' },
                { icon: 'mdi-account', text: 'RoleDashboad', route: '/roleDashboad' },
                { icon: 'mdi-account', text: 'Person management', route: '/management-person' },
                { icon: 'mdi-account', text: 'Chart', route: '/chart' },
            ]
        }
    },
    components: {
        Popup,
    },
    methods : {
        logout(){
            this.$store.dispatch("logout");
            this.$router.push("singIn");
        },
        checkAuth(){
            return this.$store.state.auth
        }
    }
}
</script>
