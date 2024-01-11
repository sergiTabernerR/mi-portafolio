package com.example.gestiobus

import android.content.Intent
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.gestiobus.databinding.CardViewParadaBinding

class AdaptadorParades(val llista: List<Parada>): RecyclerView.Adapter<AdaptadorParades.ViewHolder>() {
    class ViewHolder(vista: View): RecyclerView.ViewHolder(vista) {
        val nomParada: TextView

        private val binding = CardViewParadaBinding.bind(vista)

        init {
            nomParada = binding.nomParada
        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): AdaptadorParades.ViewHolder {
        val layout= LayoutInflater.from(parent.context)
        return ViewHolder(layout.inflate(R.layout.card_view_parada, parent, false))
    }

    override fun onBindViewHolder(holder: AdaptadorParades.ViewHolder, position: Int) {
        holder.itemView.setOnClickListener {
            val intent = Intent(holder.itemView.context, FitxaParada::class.java)
            intent.putExtra("NomParada", llista[position].nomParada)
            holder.itemView.context.startActivity(intent)
        }
        holder.nomParada.text = llista[position].nomParada

    }

    override fun getItemCount(): Int {
        return llista.size
    }
}