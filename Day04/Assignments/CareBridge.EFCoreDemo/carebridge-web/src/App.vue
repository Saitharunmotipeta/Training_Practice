<script setup>
import { ref, onMounted, computed } from 'vue'

// Table data
const patients = ref([])

// Search inputs
const city = ref('')
const fullName = ref('')

const searchDisabled = ref(false)

const resultCount = computed(() => patients.value.length)

// Load all patients
const loadPatients = async () => {

  const response = await fetch(
    'https://localhost:7052/api/patients'
  )

  patients.value = await response.json()
}

// Search patients
const searchPatients = async () => {

  searchDisabled.value = true   // 🔒 disable button

  const url = new URL('https://localhost:7052/api/patients/search')

  if (city.value) {
    url.searchParams.append('city', city.value)
  }

  if (fullName.value) {
    url.searchParams.append('fullName', fullName.value)
  }

  url.searchParams.append('isActive', true)

  const response = await fetch(url)

  const data = await response.json()

  patients.value = data
}

// Reset filters
const reset = () => {

  city.value = ''
  fullName.value = ''

  searchDisabled.value = false   

  loadPatients()
}

onMounted(() => {
  loadPatients()
})

</script>

<template>

  <h1>CareBridge Patients</h1>

  <p>City :</p>
  <input type="text" v-model="city" />

  <p>Full Name :</p>
  <input type="text" v-model="fullName" />

  <br><br>

  <button
    @click="searchPatients"
    :disabled="searchDisabled">
    Search
  </button>

  <button @click="reset">
    Reset
  </button>

  <br><br>

  <!-- 🔥 RESULT COUNT -->
  <p v-if="patients.length">
    Showing {{ resultCount }} entrie(s)
  </p>

  <p v-else>
    No results found
  </p>

  <table border="1">

    <tr>
      <th>Patient Id</th>
      <th>Full Name</th>
      <th>City</th>
    </tr>

    <tr v-for="p in patients" :key="p.patientId">

      <td>{{ p.patientId }}</td>
      <td>{{ p.fullName }}</td>
      <td>{{ p.city }}</td>

    </tr>

  </table>

</template>