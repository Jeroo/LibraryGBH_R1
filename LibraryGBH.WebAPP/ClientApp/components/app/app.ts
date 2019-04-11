import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
    components: {
        HeaderComponent: require('../header/header.vue.html'),
    }
})
export default class AppComponent extends Vue {
}
