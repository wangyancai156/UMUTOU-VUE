<template>
    <div>
        <el-table :data="table" style="width: 100%; "  >
            <el-table-column type="selection" width="55">
            </el-table-column>
            <el-table-column prop="CreateUserId" label="CreateUserId" width="180">
            </el-table-column>
            <el-table-column prop="Id" label="Id" width="180">
            </el-table-column>
            <el-table-column prop="CurrentQty" label="地址">
            </el-table-column>
            <el-table-column fixed="right" label="操作" width="120">
                <template slot-scope="scope">
                    <el-button type="text" size="small">
                        移除
                    </el-button>
                </template>
            </el-table-column>
        </el-table>
        <div class="block">
            <el-pagination @size-change="handleSizeChange" @current-change="handleCurrentChange" :current-page="PageIndex" :page-sizes="[5, 10, 20, 100]" :page-size="pagesize" layout="total, sizes, prev, pager, next, jumper" :total="TotalCount">
            </el-pagination>
        </div>
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
            pagesize: 10,
            PageIndex: 1,
            TotalCount: 0,
            table: []
        };
    },
    mounted() {
        this.getjson();
    },
    methods: {
      
        handleSizeChange: function(size) {
            this.pagesize = size;
            this.getjson();
        },
        handleCurrentChange: function(PageIndex) {
            this.PageIndex = PageIndex;
            this.getjson();
        },
        getjson() {
            this.$http
                .get("/api/api/InOutBound/GetSpotInventoryPaged", {
                    params: {
                        pageIndex: this.PageIndex,
                        pageSize: this.pagesize,
                        productid: ""
                    }
                })
                .then(res => {
                    this.table = res.data.EntityList;
                    this.TotalCount = res.data.TotalCount;
                    this.PageIndex = res.data.PageIndex;
                    console.log(res.data.EntityList);
                });
        }
    }
};
</script>