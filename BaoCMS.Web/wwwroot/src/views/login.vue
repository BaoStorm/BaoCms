<template>
    <div class="index">
        <Row type="flex" justify="center" align="top">
            <Col offset="0">
            <h1>
                <img src="https://raw.githubusercontent.com/iview/iview/master/assets/logo.png">
            </h1>
            </Col>
        </Row>
        <Row type="flex" justify="center" align="middle">
            <Col :xs="22" :sm="18" :md="14" :lg="8">
            <Form ref="formValidate" :model="formValidate" :rules="ruleValidate" :label-width="80">
                <Form-item label="账号" prop="name">
                    <Input v-model="formValidate.name" placeholder="请输入账号"></Input>
                </Form-item>
                <Form-item label="密码" prop="pwd">
                    <Input v-model="formValidate.pwd" placeholder="请输入密码"></Input>
                </Form-item>
                <Form-item>
                    <Button type="primary" @click="handleSubmit('formValidate')">提交</Button>
                    <Button type="ghost" @click="handleReset('formValidate')" style="margin-left: 8px">重置</Button>
                </Form-item>
            </Form>
            </Col>
        </Row>
    </div>
</template>
<script>
    export default {
        data() {
            return {
                formValidate: {
                    name: '',
                    pwd: '',
                    city: ''
                },
                ruleValidate: {
                    name: [
                        { required: true, message: '账号不能为空', trigger: 'blur' }
                    ],
                    pwd: [
                        { required: true, message: '密码不能为空', trigger: 'blur' },
                    ],
                    city: [
                        { required: true, message: '请选择城市', trigger: 'change' }
                    ],
                }
            }
        },
        methods: {
            handleSubmit(name) {
                this.$refs[name].validate((valid) => {
                    if (valid) {
                        this.$Message.success('提交成功!');
                    } else {
                        this.$Message.error('表单验证失败!');
                    }
                })
            },
            handleReset(name) {
                this.$refs[name].resetFields();
            }
        }
    }
</script>
