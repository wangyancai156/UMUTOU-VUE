<template>
    <div>
        <el-table :data="tableData2" style="width: 100%" :row-class-name="tableRowClassName">
            <el-table-column type="selection" width="55">
            </el-table-column>
            <el-table-column prop="Name" label="Name" width="180">
            </el-table-column>
            <el-table-column prop="Id" label="Id" width="180">
            </el-table-column>
            <el-table-column prop="Note" label="地址">
            </el-table-column>
            <el-table-column fixed="right" label="操作" width="120">
                <template slot-scope="scope">
                    <el-button   type="text" size="small">
                        移除
                    </el-button>
                </template>
            </el-table-column>
        </el-table>

    </div>
</template>

<style>
.el-table .warning-row {
    background: oldlace;
}

.el-table .success-row {
    background: #f0f9eb;
}
</style>

<script>
export default {
    data() {
        return {
            tableData2: []
        };
    },
    mounted() {
        this.getjson();
    },
    methods: {
        getjson() {
            this.$http.get("/api/api/Warehouse").then(res => {
                this.tableData2 = res.data;
            });
        }
    }
};
</script>