<script setup>
import { ref, onMounted, computed } from 'vue'

const departments = ref([])

// load dashboard data
const loadDashboard = async () => {

  const response = await fetch(
    'https://localhost:7052/api/analytics/department-load'
  )

  departments.value = await response.json()
}

// find max total (busiest department)
const maxTotal = computed(() => {
  if (!departments.value.length) return 0
  return Math.max(...departments.value.map(d => d.total))
})

// highlight row if it is busiest
const isBusiest = (dept) => {
  return dept.total === maxTotal.value
}

onMounted(() => {
  loadDashboard()
})

</script>

<template>

  <h1>Department Load Dashboard</h1>

  <table border="1" cellpadding="8">

    <tr>
      <th>Department</th>
      <th>Inpatient</th>
      <th>Outpatient</th>
      <th>ED</th>
      <th>Total</th>
    </tr>

    <tr
      v-for="d in departments"
      :key="d.departmentName"
      :class="{ highlight: isBusiest(d) }">

      <td>{{ d.departmentName }}</td>
      <td>{{ d.inpatient }}</td>
      <td>{{ d.outpatient }}</td>
      <td>{{ d.ed }}</td>
      <td><b>{{ d.total }}</b></td>

    </tr>

  </table>

</template>

<style scoped>
.highlight {
  background-color: #ffe08a;
  font-weight: bold;
}
</style>