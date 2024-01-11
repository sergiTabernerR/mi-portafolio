package com.example.gestiobus

import android.Manifest
import android.app.AlertDialog
import android.content.ContentValues.TAG
import android.content.Intent
import android.content.pm.PackageManager
import android.location.Location
import android.location.LocationListener
import android.location.LocationManager
import android.os.Build
import android.os.Bundle
import android.speech.tts.TextToSpeech
import android.view.Menu
import android.view.MenuItem
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.core.app.ActivityCompat
import com.example.gestiobus.databinding.ActivityFitxaParadaBinding
import com.google.android.gms.maps.GoogleMap
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import java.time.LocalTime
import java.time.format.DateTimeFormatter
import java.util.*


class FitxaParada : AppCompatActivity() {
    private lateinit var binding: ActivityFitxaParadaBinding
    private lateinit var mMap: GoogleMap
    private var pLong: Double = 0.0
    private var pLat: Double = 0.0
    private var horas = ArrayList<String>()
    private var horaSeguent: LocalTime = LocalTime.MIN
    var horariListIndex:Int = 0
    var textToSpeech: TextToSpeech? = null
    companion object{
         var idLinia:String = ""
         var idParada:String = ""
         var nomLinia:String = ""
         var nomParada:String = ""
         var nomParadaCompert:String = ""
         var coordenadasParadasLong = ArrayList<Double>()
         var coordenadasParadasLat = ArrayList<Double>()

    }
    val locationDevice = Location("Android Device Location.")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityFitxaParadaBinding.inflate(layoutInflater)
        setContentView(binding.root)
        getRetrofit()
        var intentlinia = intent.getStringExtra("idLinia")
        var linia = intent.getStringExtra("linia")
        var parada = intent.getStringExtra("descripcio")
        if(intentlinia != null) {
            idLinia = intentlinia.toString()

        }
        if(linia !=null || parada !=null){
            nomLinia = linia.toString()
            nomParada = parada.toString()
        }
        getBusStopinformation()

        var NomParada = findViewById<TextView>(R.id.parada)
        var NomLinia = findViewById<TextView>(R.id.viewLinia)

        NomParada.text = nomParada
        NomLinia.text = nomLinia


        binding.secuenciaParada.setOnClickListener {
            val intent = Intent(this, SegmentRepresentacioParades::class.java)
            intent.putExtra("menuParada", true)
            startActivity(intent)
        }
        binding.llocsEmblematics.setOnClickListener {
            val intent = Intent(this,llocsEmblematics::class.java)
            startActivity(intent)
        }
        binding.mapa.setOnClickListener {
            val intent = Intent(this,rutaParadas::class.java)
            startActivity(intent)
        }
        binding.btnseg.setOnClickListener {
            if(horariListIndex < horas.size-1){
                horariListIndex++
                binding.hora.text = horas.get(horariListIndex)
            }

        }
        binding.btnant.setOnClickListener {
            if(horariListIndex > 0){
                horariListIndex--
                binding.hora.text = horas.get(horariListIndex)
            }

        }

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
            ActivityCompat.requestPermissions(
                this,
                arrayOf(Manifest.permission.ACCESS_FINE_LOCATION),
                1
            )
            if (ActivityCompat.checkSelfPermission(
                    this,
                    Manifest.permission.ACCESS_FINE_LOCATION
                ) != PackageManager.PERMISSION_GRANTED
            ) {

            }
            val locationManager = getSystemService(LOCATION_SERVICE) as LocationManager
            var location: Location? = null
            val mlocListener: LocationListener = object : LocationListener {
                override fun onLocationChanged(location: Location) {}
                override fun onStatusChanged(provider: String, status: Int, extras: Bundle) {}
                override fun onProviderEnabled(provider: String) {}
                override fun onProviderDisabled(provider: String) {}
            }
            locationManager!!.requestLocationUpdates(
                LocationManager.GPS_PROVIDER,
                0,
                0f,
                mlocListener
            )
            if (locationManager != null) {
                //Existe GPS_PROVIDER obtiene ubicación
                location = locationManager.getLastKnownLocation(LocationManager.GPS_PROVIDER)
            }
            if (location == null) { //Trata con NETWORK_PROVIDER
                locationManager!!.requestLocationUpdates(
                    LocationManager.NETWORK_PROVIDER,
                    0,
                    0f,
                    mlocListener
                )
                if (locationManager != null) {
                    //Existe NETWORK_PROVIDER obtiene ubicación
                    location =
                        locationManager.getLastKnownLocation(LocationManager.NETWORK_PROVIDER)
                }
            }

            if (location != null) {

              locationDevice.setLatitude(location.longitude)
              locationDevice.setLongitude(location.latitude)
                 // locationDevice.setLatitude(2.2830)
                 //locationDevice.setLongitude(41.6007)


            } else {
                Toast.makeText(this, "No se pudo obtener geolocalización", Toast.LENGTH_LONG).show()
            }
        }

    }
    private fun getRetrofit(): Retrofit {

        return Retrofit.Builder()
            .baseUrl("https://gestiobuswebservice.conveyor.cloud/api/GestioBus/")
            .addConverterFactory(GsonConverterFactory.create()).build()

    }


    private fun getBusStopinformation() {
       var idP = "0"
       var encontrado:Int = 0
        CoroutineScope(Dispatchers.IO).launch {
            val locationValue = Location("location value.")

            val parades = getRetrofit().create(ApiService::class.java).getParada("parades/$idLinia/false/false")
            withContext(Dispatchers.Main) {

                for (parada in parades.body()!!) {
                    Geography.parseWKT(parada.coord?.geography)
                    pLong = parada.coord?.geography?.long!!
                    pLat = parada.coord?.geography?.lat!!
                    coordenadasParadasLong.add(pLong)
                    coordenadasParadasLat.add(pLat)
                    locationValue.setLatitude(pLat) //Latitud
                    locationValue.setLongitude(pLong) //Longitud

                    val distanceInMeters: Float = locationDevice.distanceTo(locationValue)

                    if (distanceInMeters < 8) {
                        encontrado++
                        if(encontrado == 1){
                        binding.viewParada.text = parada.nomParada.toString()
                        nomParadaCompert = parada.nomParada.toString()
                        idP = parada.idParada.toString()
                        }
                    }

                }


            }

            var horaris = getRetrofit().create(ApiService::class.java).getHorari("horaris/$idLinia/$idP")

            val formatter = DateTimeFormatter.ofPattern("HH:mm:ss")
            val alertDialogBuilder = AlertDialog.Builder(this@FitxaParada)
            alertDialogBuilder.setMessage("No hi han mes autobusos")

            runOnUiThread {
                for (horari in horaris.body()!!) {
                    horas.add(horari)
                }

            try{
                val ultHora = LocalTime.parse(horas.last(), formatter)
                if (LocalTime.now().compareTo(ultHora) >= 0) {
                    alertDialogBuilder.setPositiveButton(android.R.string.yes) { dialog, which ->
                    }
                    alertDialogBuilder.show()
                } else {
                    for (hora in horas) {
                        val h = LocalTime.parse(hora, formatter)

                        if (h.compareTo(LocalTime.now()) >= 0) {
                            horaSeguent = h

                            horariListIndex = horas.indexOf(horaSeguent.toString() + ":00")

                            textToSpeech = TextToSpeech(
                                applicationContext
                            ) { i ->

                                if (i != TextToSpeech.ERROR) {
                                    var español:Locale = Locale("es","ES")
                                    textToSpeech!!.language = español
                                    textToSpeech!!.speak("El siguiente bus sale a las "+ horaSeguent, TextToSpeech.QUEUE_FLUSH, null)
                                }
                            }
                            binding.hora.text = horaSeguent.toString() +":00"
                            break
                        }
                    }
                }

            }catch (e:Exception){
                val intent = Intent(this@FitxaParada, SegmentRepresentacioParades::class.java)
                startActivity(intent)
                Toast.makeText(this@FitxaParada, "No estas cerca de ninguna Parada", Toast.LENGTH_LONG).show()

            }
           }
        }

    }
    override fun onCreateOptionsMenu(menu: Menu?): Boolean {
        menuInflater.inflate(R.menu.option_menu, menu)
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.P) {
            menu!!.setGroupDividerEnabled(true)
        }
        return true
    }

    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        when (item.itemId) {
            R.id.tablaParades -> {
                val intent = Intent(this, LlistaParades::class.java)
                startActivity(intent)
            }
            else ->  onSupportNavigateUp()
        }
        return true
    }

    override fun onSupportNavigateUp(): Boolean {
        onBackPressed();
        return super.onSupportNavigateUp()
    }

    override fun onRequestPermissionsResult(
        requestCode: Int,
        permissions: Array<out String>,
        grantResults: IntArray
    ) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults)
        when (requestCode) {
            MainActivity.REQUEST_CODE_lOCATION -> if (grantResults.isNotEmpty() && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                if (ActivityCompat.checkSelfPermission(
                        this,
                        Manifest.permission.ACCESS_FINE_LOCATION
                    ) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(
                        this,
                        Manifest.permission.ACCESS_COARSE_LOCATION
                    ) != PackageManager.PERMISSION_GRANTED
                ) {
                    return
                }
                mMap.isMyLocationEnabled = true
            } else {
                Toast.makeText(this, "Ve a ajustes y acepta los permissos", Toast.LENGTH_SHORT)
                    .show()

            }
            else -> {}

        }
    }

}



