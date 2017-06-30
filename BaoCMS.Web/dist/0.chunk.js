webpackJsonp([0],{

/***/ 58:
/***/ (function(module, exports, __webpack_require__) {


/* styles */
__webpack_require__(60)

var Component = __webpack_require__(18)(
  /* script */
  __webpack_require__(59),
  /* template */
  __webpack_require__(61),
  /* scopeId */
  "data-v-35c45444",
  /* cssModules */
  null
)
Component.options.__file = "C:\\Users\\bx666\\Documents\\Visual Studio 2017\\Projects\\BaoCMS\\BaoCMS.Web\\src\\views\\index.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] index.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (true) {(function () {
  var hotAPI = __webpack_require__(5)
  hotAPI.install(__webpack_require__(1), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-35c45444", Component.options)
  } else {
    hotAPI.reload("data-v-35c45444", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 59:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
    methods: {
        handleStart() {
            this.$Modal.info({
                title: 'Bravo',
                content: 'Now, enjoy the convenience of iView.'
            });
        }
    }
});

/***/ }),

/***/ 60:
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ 61:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "index"
  }, [_c('Row', {
    attrs: {
      "type": "flex",
      "justify": "center",
      "align": "middle"
    }
  }, [_c('Col', {
    attrs: {
      "span": "24"
    }
  }, [_c('h1', [_c('img', {
    attrs: {
      "src": "https://raw.githubusercontent.com/iview/iview/master/assets/logo.png"
    }
  })]), _vm._v(" "), _c('h2', [_c('p', [_vm._v("Welcome to your iView app!")]), _vm._v(" "), _c('Button', {
    attrs: {
      "type": "ghost"
    },
    on: {
      "click": _vm.handleStart
    }
  }, [_vm._v("Start iView")])], 1)])], 1)], 1)
},staticRenderFns: []}
module.exports.render._withStripped = true
if (true) {
  module.hot.accept()
  if (module.hot.data) {
     __webpack_require__(5).rerender("data-v-35c45444", module.exports)
  }
}

/***/ })

});
//# sourceMappingURL=0.chunk.js.map