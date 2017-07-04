const adminPath = '/admin';
import index from './views/index'
import demo from './views/demo'
import login from './views/login'

const routers = [
    { path: '/', meta: {title: ''} ,component: index },
    { path: '/demo/', meta: { title: '' }, component: demo },
    { path: '/login/', meta: { title: '' }, component: login }
];


export default routers;