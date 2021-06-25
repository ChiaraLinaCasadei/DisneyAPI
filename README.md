# DisneyAPI
Challenge solicitado para Alkemy, con C# y Net 5

# Aclaraciones y Dificultades

Al realizar la carga se produce una referencia circular, ya que Personaje contiene una lista del tipo Pelicula/Serie, donde cada Pelicula/Serie a su vez, contiene su propia lista de Personajes.

No he logrado aún resolverla sin que implique rediseñar el modelado de la base de datos.

