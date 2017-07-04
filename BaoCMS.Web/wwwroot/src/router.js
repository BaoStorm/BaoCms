const adminPath = '/admin';
import index from './views/index'
import demo from './views/demo'

const routers = [{
    path: '/',
    meta: {
        title: ''
    },
    component: index
},
    {
        path: '/demo/',
        meta: {
            title: ''
        },
        component: demo
    }
];


export default routers;