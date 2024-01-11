package com.example.gestiobus

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.gestiobus.databinding.ActivityMainBinding
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import java.lang.Exception

class SegmentRepresentacioParades : AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding
    private lateinit var adaptadorParades: AdaptadorSecuenciaParades
    private lateinit var idLinia:String
    private var Parada = mutableListOf<Parada>()
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)
        initRecyclerViewParada()
        getParades()

}
    private fun getRetrofit(): Retrofit {
      return Retrofit.Builder()
            .baseUrl("https://gestiobuswebservice.conveyor.cloud/api/GestioBus/")
            .addConverterFactory(GsonConverterFactory.create()).build()



    }

    private fun getParades() {
       idLinia =FitxaParada.idLinia
        CoroutineScope(Dispatchers.IO).launch {
            val call = getRetrofit().create(ApiService::class.java).getParada("parades/$idLinia/false/false")
            val parada = call.body()
            runOnUiThread {
                try {
                    Parada = parada as MutableList<Parada>
                    adaptadorParades = AdaptadorSecuenciaParades(Parada)
                    binding.rv1.layoutManager = LinearLayoutManager(binding.rv1.context)
                    binding.rv1.adapter = adaptadorParades

                }catch(e: Exception)
                {
                    Toast.makeText(this@SegmentRepresentacioParades,"No es poden conseguir les parades" + idLinia, Toast.LENGTH_SHORT).show()
                }

            }
        }
    }

    private fun initRecyclerViewParada() {
        adaptadorParades = AdaptadorSecuenciaParades(Parada)
        binding.rv1.layoutManager = LinearLayoutManager(this)
        binding.rv1.adapter = adaptadorParades
    }

    override fun onSupportNavigateUp(): Boolean {
        onBackPressed();
        return super.onSupportNavigateUp()
    }
}
