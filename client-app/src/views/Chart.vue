<template>
  <div>
    <organization-chart :datasource="ds"></organization-chart>
  </div>
</template>
<script>
  import OrganizationChart from '../components/OrganizationChartContainer'
  import 'vue-organization-chart/dist/orgchart.css'
import api from '../api';
  export default {
    components: {
      OrganizationChart
    },
    mounted() {
      this.getData()
    },
    data () {
      return {
        ds: {
        'id': 1,
        'name': 'Lao Lao',
        'titlae': 'general manager',
        'children': []
        }
      }
    },
    methods : {
      getData(){
        api.getChart().then(data => {
        this.error= false;
        this.ds = data.data.data;
        }).catch(error => {
          console.log(error);
          this.error= true;
          if (error.status === 401 && error.headers.has('Token-Expired')) {
              this.$router.push("/signIn");
          }
          this.ds = {}
        });
      }
    }
  }
  // ds: {
//           'id': '1',
//           'name': 'Lao Lao',
//           'title': 'general manager',
//           'children': [
//             { 'id': '2', 'name': 'Bo Miao', 'title': 'department manager' },
//             { 'id': '2', 'name': 'Bo Miao', 'title': 'department manager' },
//             { 'id': '3', 'name': 'Su Miao', 'title': 'department manager',
//               'children': [
//                 { 'id': '4', 'name': 'Tie Hua', 'title': 'senior engineer' },
//                 { 'id': '5', 'name': 'Hei Hei', 'title': 'senior engineer',
//                   'children': [
//                     { 'id': '6', 'name': 'Pang Pang', 'title': 'engineer',
//                       'children': [
//                         { 'id': '6', 'name': 'Pang Pang', 'title': 'engineer' },
//                         { 'id': '7', 'name': 'Xiang Xiang', 'title': 'UE engineer' }
//                       ] },
                      
//                     { 'id': '7', 'name': 'Xiang Xiang', 'title': 'UE engineer' }
//                   ]
//                  }
//                ]
//              },
//             { 'id': '8', 'name': 'Hong Miao', 'title': 'department manager' },
//             { 'id': '9', 'name': 'Chun Miao', 'title': 'department manager' }
//           ]
//         }
</script>
