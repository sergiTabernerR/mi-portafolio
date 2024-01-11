package com.example.gestiobus

import android.content.Intent
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.gestiobus.databinding.CardViewParadaBinding
import com.example.gestiobus.databinding.CardViewSecuenciaparadaBinding

class AdaptadorSecuenciaParades(val llista: List<Parada>): RecyclerView.Adapter<AdaptadorSecuenciaParades.ViewHolder>() {
    class ViewHolder(vista: View): RecyclerView.ViewHolder(vista) {
        val nomParada: TextView

        private val binding = CardViewSecuenciaparadaBinding.bind(vista)

        init {
            nomParada = binding.nomParada
        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): AdaptadorSecuenciaParades.ViewHolder {
        val layout= LayoutInflater.from(parent.context)
        return ViewHolder(layout.inflate(R.layout.card_view_secuenciaparada, parent, false))
    }

    override fun onBindViewHolder(holder: AdaptadorSecuenciaParades.ViewHolder, position: Int) {
        holder.itemView.setOnClickListener {
            val intent = Intent(holder.itemView.context, FitxaActivitySecuenciaParada::class.java)
            intent.putExtra("NomParada", llista[position].nomParada)
            intent.putExtra("idParada",llista[position].idParada.toString())
            holder.itemView.context.startActivity(intent)
        }
        holder.nomParada.text = llista[position].nomParada

    }

    override fun getItemCount(): Int {
        return llista.size
    }
}