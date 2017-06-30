const adminPath = '/admin';

const routers = [{
    path: adminPath+'/',
    meta: {
        title: ''
    },
    component:(resolve) => require(['./views/index.vue'], resolve)
}
];


export default routers;