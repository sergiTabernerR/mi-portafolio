package com.example.gestiobus

import android.Manifest
import android.content.Intent
import android.content.pm.PackageManager
import android.location.Location
import android.location.LocationListener
import android.location.LocationManager
import android.os.Build
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.speech.tts.TextToSpeech
import android.view.Menu
import android.view.MenuItem
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AlertDialog
import androidx.core.app.ActivityCompat
import com.example.gestiobus.databinding.ActivityFitxaSecuenciaParadaBinding
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
import kotlin.collections.ArrayList

class FitxaActivitySecuenciaParada : AppCompatActivity() {
    private lateinit var binding: ActivityFitxaSecuenciaParadaBinding
    private var horas = ArrayList<String>()
    private var horaSeguent: LocalTime = LocalTime.MIN
    var horariListIndex:Int = 0
    var textToSpeech: TextToSpeech? = null
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityFitxaSecuenciaParadaBinding.inflate(layoutInflater)
        setContentView(binding.root)
        getRetrofit()

        var intentlinia = intent.getStringExtra("idLinia")
        var linia = intent.getStringExtra("linia")
        var parada = intent.getStringExtra("descripcio")
        if(intentlinia != null) {
            FitxaParada.idLinia = intentlinia.toString()

        }
        if(linia !=null || parada !=null){
            FitxaParada.nomLinia = linia.toString()
            FitxaParada.nomParada = parada.toString()
        }

        var NomParada = findViewById<TextView>(R.id.parada)
        var NomLinia = findViewById<TextView>(R.id.viewLinia)

        NomParada.text = FitxaParada.nomParada
        NomLinia.text = FitxaParada.nomLinia
        getBusStopinformation()

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

    }
    private fun getRetrofit(): Retrofit {

        return Retrofit.Builder()
            .baseUrl("https://gestiobuswebservice.conveyor.cloud/api/GestioBus/")
            .addConverterFactory(GsonConverterFactory.create()).build()
    }

    private fun getBusStopinformation() {

        CoroutineScope(Dispatchers.IO).launch {
            var idParada = intent.getStringExtra("idParada")
            var nomParada = intent.getStringExtra("NomParada")
            FitxaParada.idParada = idParada.toString()
            var idLinia = FitxaParada.idLinia
            var horaris = getRetrofit().create(ApiService::class.java).getHorari("horaris/$idLinia/$idParada")

            val formatter = DateTimeFormatter.ofPattern("HH:mm:ss")
            val alertDialogBuilder = AlertDialog.Builder(this@FitxaActivitySecuenciaParada)
            alertDialogBuilder.setMessage("No hi han mes autobusos")

            runOnUiThread {
                for (horari in horaris.body()!!) {
                    horas.add(horari)
                }
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
                            binding.viewParada.text = nomParada

                            break
                        }
                    }
                }


            }


        }

    }


}






