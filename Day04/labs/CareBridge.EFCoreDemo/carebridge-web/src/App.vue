<script setup>
import { ref, onMounted, computed } from 'vue'

// -------------------- DATA --------------------
const departments = ref([])

// filters
const fromDate = ref('')
const sortBy = ref('total') // 'total' | 'name'

// -------------------- API CALL --------------------
const loadDashboard = async () => {

  const url = new URL('https://localhost:7052/api/analytics/department-load')

  if (fromDate.value) {
    url.searchParams.append('fromDate', fromDate.value)
  }

  const response = await fetch(url)
  departments.value = await response.json()
}

const busiestTotal = computed(() => {
  if (!departments.value.length) return 0
  return Math.max(...departments.value.map(d => d.total))
})

const isBusiest = (d) => {
  return d.total === busiestTotal.value
}

// -------------------- SORTED DATA --------------------
const sortedDepartments = computed(() => {

  return [...departments.value].sort((a, b) => {

    if (sortBy.value === 'name') {
      return a.departmentName.localeCompare(b.departmentName)
    }

    return b.total - a.total
  })
})

// -------------------- GRAND TOTAL --------------------
const grandTotal = computed(() => {

  return departments.value.reduce((sum, d) => {
    return {
      inpatient: sum.inpatient + d.inpatient,
      outpatient: sum.outpatient + d.outpatient,
      ed: sum.ed + d.ed,
      total: sum.total + d.total
    }
  }, { inpatient: 0, outpatient: 0, ed: 0, total: 0 })
})

// -------------------- INIT --------------------
onMounted(() => {
  loadDashboard()
})

</script>

<template>

  <h1>Department Load Dashboard</h1>

  <!-- FILTERS -->
  <label>From Date:</label>
  <input type="date" v-model="fromDate" />

  <button @click="loadDashboard">
    Apply
  </button>

  <br><br>

  <!-- SORT -->
  <label>Sort By:</label>

  <select v-model="sortBy">
    <option value="total">Total</option>
    <option value="name">Department Name</option>
  </select>

  <br><br>

  <!-- TABLE -->
  <table border="1" cellpadding="8">

    <tr>
      <th>Department</th>
      <th>Inpatient</th>
      <th>Outpatient</th>
      <th>ED</th>
      <th>Total</th>
    </tr>

    <!-- DATA ROWS -->
    <tr
  v-for="d in sortedDepartments"
  :key="d.departmentName"
  :class="{ highlight: isBusiest(d) }">

      <td>{{ d.departmentName }}</td>
      <td>{{ d.inpatient }}</td>
      <td>{{ d.outpatient }}</td>
      <td>{{ d.ed }}</td>
      <td><b>{{ d.total }}</b></td>

    </tr>

    <!-- GRAND TOTAL ROW -->
    <tr style="font-weight:bold; background:#f0f0f0">

      <td>Grand Total</td>
      <td>{{ grandTotal.inpatient }}</td>
      <td>{{ grandTotal.outpatient }}</td>
      <td>{{ grandTotal.ed }}</td>
      <td>{{ grandTotal.total }}</td>

    </tr>

  </table>

</template>

<style scoped>
.highlight {
  background-color: red;
}
</style>